using AutoMapper;
using Music.BLL.DTO;
using Music.DAL.DBContext;
using Music.DAL.TablesClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.BLL.BL
{
    public class BranoService
    {
        public BranoDTO GetSingleBrano(int id)
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

        public List<BranoDTO> GetBraniDisco(int id)
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

        public List<BranoDTO> GetBrani()
        {
            List<BranoDTO> result = new List<BranoDTO>();
            using (var context = new MusicContext())
            {
                result = context.Brani.ToList()
                    .Select(b => Mapper.Map<BranoDTO>(b)).ToList();
            }
            return result;
        }

        public void SaveNewBrano(BranoDTO bdto)
        {
            using (var context = new MusicContext())
            {
                Brano brano = new Brano();
                brano.Titolo = bdto.titolo;
                brano.Durata = bdto.durata;
                brano.CreatedOn = DateTime.Now;
                brano.ModifiedOn = DateTime.Now;

                DiscoService ds = new DiscoService();
                brano.Disco_Id = ds.AddDiscoOrDefault(bdto);

                context.Brani.Add(brano);
                context.SaveChanges();
            }
        }

        public void DeleteSingleBrano(int id)
        {
            using (var context = new MusicContext())
            {
                var brano = context.Brani.FirstOrDefault(b => b.Id == id);
                context.Brani.Remove(brano);
                context.SaveChanges();
            }
        }

        public void UpdateSingleBrano(BranoDTO updated)
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
