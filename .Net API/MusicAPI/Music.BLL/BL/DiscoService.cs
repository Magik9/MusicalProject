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
        public static DiscoDTO GetSingleDisco(int id)
        {
            DiscoDTO discoDTO = null;
            using (var context = new MusicContext())
            {
                var disco = context.Dischi.FirstOrDefault(d => d.Id == id);
                if (disco != null)
                {
                    discoDTO = Mapper.Map<DiscoDTO>(disco);
                }
            }
            return discoDTO;
        }

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

        public static void SaveNewDiscoOnDB(Disco disco)
        {
            using (var context = new MusicContext())
            {
                disco.CreatedOn = DateTime.Now;
                disco.ModifiedOn = DateTime.Now;

                context.Dischi.Add(disco);
                context.SaveChanges();
            }
        }

        public static void UpdateDiscoOnDB(DiscoDTO discoDTO)
        {
            using (var context = new MusicContext())
            {
                Disco oldDisco = context.Dischi.SingleOrDefault(x => x.Id == discoDTO.Id);
                Mapper.Map(discoDTO, oldDisco);
                oldDisco.ModifiedOn = DateTime.Now;

                context.SaveChanges();
            }
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
                    var d = context.Bands.SingleOrDefault(b => b.Id == band.Id)
                        .Dischi.SingleOrDefault(x => x.Titolo == discoDTO.titolo);
                    if (d == null)
                        discoDTO.Band_Id = band.Id;
                    else
                        return d;
                }
                else
                    discoDTO.Band_Id = context.Bands.ToList().Last().Id;

                Mapper.Map(discoDTO, disco);
                SaveNewDiscoOnDB(disco);

                return null;
            }
        }

        public static void UpdateDisco(DiscoDTO discoDTO)
        {
            using (var context = new MusicContext())
            {
                BandDTO bandDTO = Mapper.Map<BandDTO>(discoDTO);
                Band band = BandService.AddBandIfNotExist(bandDTO);
                if (band != null) //se la band esiste gia
                {
                    var d = context.Bands.SingleOrDefault(b => b.Id == band.Id)
                        .Dischi.SingleOrDefault(x => x.Titolo == discoDTO.titolo && x.Id != discoDTO.Id);
                    if (d == null)
                        discoDTO.Band_Id = band.Id;
                    else
                        return;
                }
                else
                    discoDTO.Band_Id = context.Bands.ToList().Last().Id;

                UpdateDiscoOnDB(discoDTO);
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
