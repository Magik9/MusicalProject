using AutoMapper;
using Music.BLL.DTO;
using Music.DAL.DBContext;
using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Music.BLL.BL
{
    public class BandService
    {
        public List<BandDTO> GetBands()
        {
            List<BandDTO> result = new List<BandDTO>();
            using (var context = new MusicContext())
            {
                result = context.Bands.ToList()
                    .Select(b => Mapper.Map<BandDTO>(b)).ToList();
            }
            return result;
        }

        public int AddBandOrDefault(BranoDTO bdto)
        {
            Band band = new Band();
            using (var context = new MusicContext())
            {
                var b = context.Bands.FirstOrDefault(x => x.Nome == bdto.band);
                if (b == null)
                {
                    band.Nome = bdto.band;
                    band.Id = context.Bands.ToList().Last().Id;
                    band.CreatedOn = DateTime.Now;
                    band.ModifiedOn = DateTime.Now;

                    context.Bands.Add(band);
                    context.SaveChanges();
                    return band.Id;
                }
                else
                    return b.Id;
            }

        }

        public void DeleteBand(int id)
        {
            using (var context = new MusicContext())
            {
                context.Bands.Remove(context.Bands.FirstOrDefault(x => x.Id == id));
                context.SaveChanges();
            }
        }
    }
}
