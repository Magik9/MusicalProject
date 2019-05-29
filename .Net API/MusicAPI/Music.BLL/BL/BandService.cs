using AutoMapper;
using Music.BLL.DTO;
using Music.DAL.DBContext;
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
    }
}
