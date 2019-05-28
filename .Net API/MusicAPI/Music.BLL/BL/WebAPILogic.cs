﻿using System.Collections.Generic;
using System.Linq;
using Music.DAL.TablesClasses;
using Music.BLL.DTO;
using Music.DAL.DBContext;
using AutoMapper;
using System;

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
                result = context.Dischi.ToList()
                    .Select(d => Mapper.Map<DiscoDTO>(d)).ToList();
            }
            return result;
        }

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

        public void SaveNewBrano(BranoDTO bdto)
        {
            using (var context = new MusicContext())
            {
                Brano brano = new Brano();
                brano.Titolo = bdto.titolo;
                brano.Durata = bdto.durata;
                brano.CreatedOn = DateTime.Now;
                brano.ModifiedOn = DateTime.Now;

                var disco = context.Dischi.FirstOrDefault(d => d.Titolo == bdto.disco);
                if (disco != null)
                    brano.Disco_Id = disco.Id;
                else
                    brano.Disco_Id = context.Dischi.ToList().Last().Id;

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
