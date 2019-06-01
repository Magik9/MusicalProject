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

        public int AddBandIfNotExist(BandDTO bandDto)
        {
            Band band = new Band();
            using (var context = new MusicContext())
            {
                var b = context.Bands.FirstOrDefault(x => x.Nome == bandDto.nome);
                if (b == null)
                {
                    band.Nome = bandDto.nome;
                    band.CreatedOn = DateTime.Now;
                    band.ModifiedOn = DateTime.Now;

                    context.Bands.Add(band);
                    context.SaveChanges();
                    return band.Id;
                }
                    return b.Id;
            }
        }

        public int AddBandIfNotExist(DiscoDTO discoDTO)
        {
            BandDTO bandDTO = new BandDTO()
            {
                nome = discoDTO.band,
                annoFondazione = discoDTO.anno,
                genere = discoDTO.genere
            };
            return AddBandIfNotExist(bandDTO);
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
