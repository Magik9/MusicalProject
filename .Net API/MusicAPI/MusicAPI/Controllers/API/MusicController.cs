using MusicAPI.Models.ClassiTabelle;
using MusicAPI.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using MusicAPI.BLL.DTO;

namespace MusicAPI.Controllers.API
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("Music")]
    public class MusicController : ApiController
    {
        [HttpGet]
        
        [Route("Brano")]
        public BranoDTO Brano(int id)
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

        [HttpGet]
        [Route("Bands")]
        public List<BandDTO> ListaBands()
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

        [HttpGet]
        [Route("Dischi")]
        public List<DiscoDTO> ListaDischi()
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

        [HttpGet]
        [Route("Brani")]
        public List<BranoDTO> ListaBrani()
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

        [HttpPost]
        [Route("AddBrano")]
        public void AddBrano(BranoDTO bdto)
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

        [HttpDelete]
        [Route("DeleteBrano")]
        public void DeleteBrano(int id)
        {
            using (var context = new MusicContext())
            {
                var brano = context.Brani.FirstOrDefault(b => b.id == id);
                context.Brani.Remove(brano);
                context.SaveChanges();
            }
        }

        [HttpPut]
        [Route("UpdateBrano")]
        public void UpdateBrano(BranoDTO updated)
        {
            using (var context = new MusicContext())
            {
                Brano brano = context.Brani.FirstOrDefault(b => b.id == updated.id);
                brano.titolo = updated.titolo;
                brano.durata = updated.durata;

                context.SaveChanges();
            }
        }

    }
}

