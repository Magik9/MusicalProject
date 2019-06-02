using AutoMapper;
using Music.BLL.DTO;
using Music.DAL.DBContext;
using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Music.BLL.BL
{
    public static class BandService
    {
        public static List<BandDTO> GetBands()
        {
            List<BandDTO> result = new List<BandDTO>();
            using (var context = new MusicContext())
            {
                result = context.Bands.ToList()
                    .Select(b => Mapper.Map<BandDTO>(b)).ToList();
            }
            return result;
        }

        public static void SaveBandOnDB(Band band)
        {
            using (var context = new MusicContext())
            {
                band.CreatedOn = DateTime.Now;
                band.ModifiedOn = DateTime.Now;

                context.Bands.Add(band);
                context.SaveChanges();
            }
        }

        public static Band BandFrom(BandDTO bandDTO)
        {
            Band band = new Band();
            Mapper.Map(bandDTO, band);

            return band;
        }

        public static Band AddBandIfNotExist(BandDTO bandDTO)
        {
            using (var context = new MusicContext())
            {
                Band band = context.Bands.FirstOrDefault(x => x.Nome == bandDTO.nome);
                if (band == null)
                {
                    band = BandFrom(bandDTO);
                    SaveBandOnDB(band);

                    return null;
                }
                    return band;
            }
        }

        public static void DeleteBand(int id)
        {
            using (var context = new MusicContext())
            {
                context.Bands.Remove(context.Bands.FirstOrDefault(x => x.Id == id));
                context.SaveChanges();
            }
        }
    }
}
