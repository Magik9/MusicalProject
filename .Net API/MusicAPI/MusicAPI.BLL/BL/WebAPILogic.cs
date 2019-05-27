using System.Collections.Generic;
using System.Linq;
using MusicAPI.DAL.TablesClasses;
using MusicAPI.BLL.DTO;
using MusicAPI.DAL.DBContext;

namespace MusicAPI.BLL.BL
{
    public class WebAPILogic
    {
        public BranoDTO GetSingleBrano(int id)
        {
            BranoDTO bdto = new BranoDTO();
            using (var context = new MusicContext())
            {
                var brano = context.Brani.FirstOrDefault(b => b.id == id);
                if (brano != null)
                {
                    bdto.id = brano.id;
                    bdto.titolo = brano.titolo;
                    bdto.durata = brano.durata;
                    bdto.anno = context.Dischi.FirstOrDefault(d => d.id == brano.Disco_Id).anno;
                    bdto.band = context.Bands.FirstOrDefault(
                        x => x.id == context.Dischi.FirstOrDefault(
                            d => d.id == brano.Disco_Id).Band_id).nome;
                    bdto.disco = context.Dischi.FirstOrDefault(d => d.id == brano.Disco_Id).Titolo;
                }
            }
            return bdto;
        }

        public List<BranoDTO> GetBrani()
        {
            List<BranoDTO> result = new List<BranoDTO>();
            using (var context = new MusicContext())
            {
                var query = context.Brani;
                result = query.Select(b => new BranoDTO
                {
                    id = b.id,
                    titolo = b.titolo,
                    band = context.Bands.FirstOrDefault(
                        x => x.id == context.Dischi.FirstOrDefault(
                            d => d.id == b.Disco_Id).Band_id).nome,
                    disco = context.Dischi.FirstOrDefault(d => d.id == b.Disco_Id).Titolo,
                    anno = context.Dischi.FirstOrDefault(d => d.id == b.Disco_Id).anno,
                    durata = b.durata
                }).ToList();
            }
            return result;
        }

        public List<DiscoDTO> GetDischi()
        {
            List<DiscoDTO> result = new List<DiscoDTO>();
            using (var context = new MusicContext())
            {
                result = context.Dischi.Select(d => new DiscoDTO
                {
                    id = d.id,
                    Titolo = d.Titolo,
                    anno = d.anno,
                    Brani = d.Brani.Select(b => new BranoDTO
                    {
                        id = b.id,
                        titolo = b.titolo,
                        anno = b.Disco.anno,
                        band = context.Bands.FirstOrDefault(
                                            x => x.id == context.Dischi.FirstOrDefault(
                                            y => y.id == b.Disco_Id).Band_id).nome,
                        disco = context.Dischi.FirstOrDefault(z => z.id == b.Disco_Id).Titolo,
                        durata = b.durata
                    }).ToList()
                }).ToList();
            }
            return result;
        }

        public List<BandDTO> GetBands()
        {
            List<BandDTO> result = new List<BandDTO>();
            using (var context = new MusicContext())
            {
                result = context.Bands.Select(b => new BandDTO
                {
                    id = b.id,
                    nome = b.nome,
                    genere = b.genere,
                    anno = b.anno,
                    nMembri = b.nMembri
                }).ToList();
            }
            return result;
        }

        public void SaveNewBrano(BranoDTO bdto)
        {
            using (var context = new MusicContext())
            {
                Brano brano = new Brano();
                brano.titolo = bdto.titolo;
                brano.durata = bdto.durata;

                var disco = context.Dischi.FirstOrDefault(d => d.Titolo == bdto.disco);
                if (disco != null)
                    brano.Disco_Id = disco.id;
                else
                    brano.Disco_Id = context.Dischi.ToList().Last().id;

                var band = context.Bands.FirstOrDefault(b => b.nome == bdto.band);
                if (band != null)
                    brano.id_band = band.id;
                else
                    brano.id_band = context.Bands.ToList().Last().id;

                context.Brani.Add(brano);
                context.SaveChanges();
            }
        }

        public void DeleteSingleBrano(int id)
        {
            using (var context = new MusicContext())
            {
                var brano = context.Brani.FirstOrDefault(b => b.id == id);
                context.Brani.Remove(brano);
                context.SaveChanges();
            }
        }

        public void UpdateSingleBrano(BranoDTO updated)
        {
            using (var context = new MusicContext())
            {
                Brano brano = context.Brani.FirstOrDefault(b => b.id == updated.id);
                Disco disco = context.Dischi.FirstOrDefault(d => d.Titolo == updated.disco);
                if (disco != null)
                    brano.Disco_Id = disco.id;
                brano.titolo = updated.titolo;
                brano.durata = updated.durata;

                context.SaveChanges();
            }
        }
    }
}
