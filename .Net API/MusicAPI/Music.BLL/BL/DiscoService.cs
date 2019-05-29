using AutoMapper;
using Music.BLL.DTO;
using Music.DAL.DBContext;
using System.Collections.Generic;
using System.Linq;


namespace Music.BLL.BL
{

    public class DiscoService
    {
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
    }
}
