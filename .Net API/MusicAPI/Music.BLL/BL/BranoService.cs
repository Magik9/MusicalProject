using AutoMapper;
using Music.BLL.DTO;
using Music.DAL.DBContext;
using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.BLL.BL
{
    public static class BranoService
    {
        public static BranoDTO GetSingleBrano(int id)
        {
            BranoDTO branoDTO = null;
            using (var context = new MusicContext())
            {
                var brano = context.Brani.FirstOrDefault(b => b.Id == id);
                if (brano != null)
                {
                    branoDTO = Mapper.Map<BranoDTO>(brano);
                }
            }
            return branoDTO;
        }

        public static List<BranoDTO> GetBraniDisco(int id)
        {
            List<BranoDTO> result = new List<BranoDTO>();
            using (var context = new MusicContext())
            {
                var disco = context.Dischi.FirstOrDefault(b => b.Id == id);
                if (disco != null)
                {
                    result = context.Brani.Where(x => x.Disco_Id == id).ToList()
                        .Select(b => Mapper.Map<BranoDTO>(b)).ToList();
                }
            }
            return result;
        }

        public static List<BranoDTO> GetBrani()
        {
            List<BranoDTO> result = new List<BranoDTO>();
            using (var context = new MusicContext())
            {
                result = context.Brani.ToList()
                    .Select(b => Mapper.Map<BranoDTO>(b)).ToList();
            }
            return result;
        }

        public static void SaveBranoOnDB(Brano brano)
        {
            using (var context = new MusicContext())
            {
                brano.CreatedOn = DateTime.Now;
                brano.ModifiedOn = DateTime.Now;

                context.Brani.Add(brano);
                context.SaveChanges();
            }
        }

        public static Brano BranoFrom(BranoDTO branoDTO)
        {
            Brano brano = new Brano();
            Mapper.Map(branoDTO, brano);

            return brano;
        }

        public static void SaveNewBrano(BranoDTO branoDTO)
        {
            using (var context = new MusicContext())
            {
                if (!string.IsNullOrEmpty(branoDTO.disco) && !string.IsNullOrEmpty(branoDTO.band))
                {
                    DiscoDTO discoDTO = Mapper.Map<DiscoDTO>(branoDTO);
                    Disco disco = DiscoService.AddDiscoIfNotExist(discoDTO);

                    branoDTO.Disco_Id =
                        disco != null
                        ?
                        disco.Id
                        :
                        context.Dischi.ToList().Last().Id;

                    Brano brano = BranoFrom(branoDTO);
                    SaveBranoOnDB(brano);
                }
            }
        }

        public static void DeleteSingleBrano(int id)
        {
            using (var context = new MusicContext())
            {
                var brano = context.Brani.FirstOrDefault(b => b.Id == id);
                context.Brani.Remove(brano);
                context.SaveChanges();
            }
        }

        public static void UpdateSingleBrano(BranoDTO updated)
        {
            using (var context = new MusicContext())
            {
                Brano brano = context.Brani.FirstOrDefault(b => b.Id == updated.id);
                Disco disco = context.Dischi.FirstOrDefault(d => d.Titolo == updated.disco);
                if (disco != null)
                    brano.Disco_Id = disco.Id;
                brano.Titolo = updated.titolo;
                brano.Durata = updated.durata;

                context.SaveChanges();
            }
        }
    }
}
