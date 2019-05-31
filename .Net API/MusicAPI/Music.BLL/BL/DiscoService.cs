using AutoMapper;
using Music.BLL.DTO;
using Music.DAL.DBContext;
using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Music.BLL.BL
{

    public class DiscoService
    {
        private BandService _bandService = null;

        public DiscoService(BandService bandService)
        {
            _bandService = bandService;
        }

        public List<DiscoDTO> GetDischi()
        {
            List<DiscoDTO> result = new List<DiscoDTO>();
            using (var context = new MusicContext())
            {
                result = context.Dischi.ToList()
                    .Select(d => Mapper.Map<DiscoDTO>(d)).ToList();
            }
            return result;
        }

        public List<DiscoDTO> GetDischiBand(int id)
        {
            List<DiscoDTO> result = new List<DiscoDTO>();
            using (var context = new MusicContext())
            {
                result = context.Dischi.ToList()
                    .Where(x => x.Band_Id == id)
                    .Select(d => Mapper.Map<DiscoDTO>(d)).ToList();
            }
            return result;
        }

        public bool AddDiscoDTO(DiscoDTO ddto)
        {
            List<DiscoDTO> result = new List<DiscoDTO>();
            using (var context = new MusicContext())
            {
                Disco disco = new Disco();
                var d = context.Dischi.FirstOrDefault(x => x.Titolo == ddto.Titolo);
                if (d == null)
                {
                    disco.Titolo = ddto.Titolo;
                    disco.Anno = ddto.anno;
                    disco.CreatedOn = DateTime.Now;
                    disco.ModifiedOn = DateTime.Now;
                    disco.Id = context.Dischi.ToList().Last().Id;

                    context.Dischi.Add(disco);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

            public int AddDiscoOrDefault(BranoDTO bdto)
            {
                Disco disco = new Disco();
                using (var context = new MusicContext())
                {
                    var d = context.Dischi.FirstOrDefault(x => x.Titolo == bdto.disco);
                    if (d == null)
                    {
                        disco.Titolo = bdto.disco;
                        disco.Anno = bdto.anno;
                        disco.CreatedOn = DateTime.Now;
                        disco.ModifiedOn = DateTime.Now;
                        disco.Id = context.Dischi.ToList().Last().Id;
                        disco.Band_Id = _bandService.AddBandOrDefault(bdto);

                        context.Dischi.Add(disco);
                        context.SaveChanges();
                        return disco.Id;
                    }
                    else
                        return d.Id;         
                }
            }

        public void DeleteDisco(int id)
        {
            using (var context = new MusicContext())
            {
                context.Dischi.Remove(context.Dischi.FirstOrDefault(x => x.Id == id));
                context.SaveChanges();
            }
        }
    }
}
