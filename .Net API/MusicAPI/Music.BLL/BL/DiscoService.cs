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

        public int AddDiscoIfNotExist(DiscoDTO ddto)
        {
            Disco disco = new Disco();
            using (var context = new MusicContext())
            {
                var d = context.Dischi.FirstOrDefault(x => x.Titolo == ddto.titolo);
                if (d == null)
                {
                    disco.Titolo = ddto.titolo;
                    disco.Anno = ddto.anno;
                    disco.CreatedOn = DateTime.Now;
                    disco.ModifiedOn = DateTime.Now;
                    disco.Band_Id = _bandService.AddBandIfNotExist(ddto);

                    context.Dischi.Add(disco);
                    context.SaveChanges();
                    return disco.Id;
                }
                    return d.Id;
            }
        }

            public int AddDiscoIfNotExist(BranoDTO branoDto)
            {
                DiscoDTO discoDto = new DiscoDTO()
                {
                    Id = branoDto.Disco_Id,
                    titolo = branoDto.disco,
                    anno = branoDto.anno,
                    band = branoDto.band
                };
                return AddDiscoIfNotExist(discoDto);
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
