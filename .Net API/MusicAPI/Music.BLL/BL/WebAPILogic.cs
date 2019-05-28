using System.Collections.Generic;
using System.Linq;
using Music.DAL.TablesClasses;
using Music.BLL.DTO;
using Music.BLL;
using Music.DAL.DBContext;
using AutoMapper;

namespace Music.BLL.BL
{
    public class WebAPILogic
    {
        public BranoDTO GetSingleBrano(int id)
        {
            BranoDTO branoDTO = new BranoDTO();
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

        public List<DiscoDTO> GetDischi()
        {
            List<DiscoDTO> result = new List<DiscoDTO>();
            using (var context = new MusicContext())
            {
                //result = context.Dischi.Select(d => new DiscoDTO
                //{
                //    id = d.id,
                //    Titolo = d.Titolo,
                //    anno = d.Anno,
                //    Brani = d.Brani.Select(b => new BranoDTO
                //    {
                //        id = b.Id,
                //        titolo = b.Titolo,
                //        anno = b.Disco.anno,
                //        band = context.Bands.FirstOrDefault(
                //                            x => x.id == context.Dischi.FirstOrDefault(
                //                            y => y.id == b.DiscoId).Band_id).nome,
                //        disco = context.Dischi.FirstOrDefault(z => z.id == b.DiscoId).Titolo,
                //        durata = b.Durata
                //    }).ToList()
                //}).ToList();
            }
            return result;
        }

        public List<BandDTO> GetBands()
        {
            List<BandDTO> result = new List<BandDTO>();
            using (var context = new MusicContext())
            {
                //result = context.Bands.Select(b => new BandDTO
                //{
                //    id = b.id,
                //    nome = b.Nome,
                //    genere = b.Genere,
                //    anno = b.AnnoFondazione,
                //    nMembri = b.NumeroMembri
                //}).ToList();
            }
            return result;
        }

        public void SaveNewBrano(BranoDTO bdto)
        {
            //using (var context = new MusicContext())
            //{
            //    Brano brano = new Brano();
            //    brano.Titolo = bdto.titolo;
            //    brano.Durata = bdto.durata;

            //    var disco = context.Dischi.FirstOrDefault(d => d.Titolo == bdto.disco);
            //    if (disco != null)
            //        brano.DiscoId = disco.id;
            //    else
            //        brano.DiscoId = context.Dischi.ToList().Last().id;

            //    var band = context.Bands.FirstOrDefault(b => b.Nome == bdto.band);
            //    if (band != null)
            //        brano.BandId = band.id;
            //    else
            //        brano.BandId = context.Bands.ToList().Last().id;

            //    context.Brani.Add(brano);
            //    context.SaveChanges();
            //}
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
            //using (var context = new MusicContext())
            //{
            //    Brano brano = context.Brani.FirstOrDefault(b => b.Id == updated.id);
            //    Disco disco = context.Dischi.FirstOrDefault(d => d.Titolo == updated.disco);
            //    if (disco != null)
            //        brano.DiscoId = disco.id;
            //    brano.Titolo = updated.titolo;
            //    brano.Durata = updated.durata;

            //    context.SaveChanges();
            //}
        }
    }
}
