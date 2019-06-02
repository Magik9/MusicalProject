using AutoMapper;
using Music.BLL.DTO;
using Music.DAL.DBContext;
using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Music.BLL.BL
{

    public static class DiscoService
    {
        

        public static List<DiscoDTO> GetDischi()
        {
            List<DiscoDTO> result = new List<DiscoDTO>();
            using (var context = new MusicContext())
            {
                result = context.Dischi.ToList()
                    .Select(d => Mapper.Map<DiscoDTO>(d)).ToList();
            }
            return result;
        }

        public static List<DiscoDTO> GetDischiBand(int id)
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

        public static void SaveDiscoOnDB(Disco disco)
        {
            using (var context = new MusicContext())
            {
                disco.CreatedOn = DateTime.Now;
                disco.ModifiedOn = DateTime.Now;

                context.Dischi.Add(disco);
                context.SaveChanges();
            }
        }

        public static Disco DiscoFrom(DiscoDTO discoDTO)
        {
            Disco disco = new Disco();
            Mapper.Map(discoDTO, disco);

            return disco;
        }

        public static Disco AddDiscoIfNotExist(DiscoDTO discoDTO)
        {
            using (var context = new MusicContext())
            {
                Disco disco = new Disco();
                BandDTO bandDTO = Mapper.Map<BandDTO>(discoDTO);
                Band band = BandService.AddBandIfNotExist(bandDTO);
                if (band != null)
                {
                    var d = context.Bands.SelectMany(y => y.Dischi).FirstOrDefault(x => x.Titolo == discoDTO.titolo);
                    if (d == null)
                        disco.Band_Id = band.Id;
                    else
                        return d;
                }
                else
                    disco.Band_Id = context.Bands.ToList().Last().Id;

                disco.Anno = discoDTO.anno;
                disco.Titolo = discoDTO.titolo;
                SaveDiscoOnDB(disco);

                return null;
            }
        }

        public static void DeleteDisco(int id)
        {
            using (var context = new MusicContext())
            {
                context.Dischi.Remove(context.Dischi.FirstOrDefault(x => x.Id == id));
                context.SaveChanges();
            }
        }
    }
}
