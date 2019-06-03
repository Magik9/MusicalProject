using Music.BLL.DTO;
using Music.BLL.BL;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Music.Controllers.API
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("Bands")]
    public class BandController : ApiController
    {
        [HttpGet]
        [Route("{id:int}")]
        public BandDTO Band(int id)
        {
            return BandService.GetSingleBand(id);
        }

        [HttpGet]
        [Route("")]
        public List<BandDTO> ListaBands()
        {
            return BandService.GetBands();
        }

        [HttpPut]
        [Route("Update")]
        public void UpdateBand(BandDTO bandDTO)
        {
            BandService.UpdateBand(bandDTO);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public void DeleteSingleBand(int id)
        {
            BandService.DeleteBand(id);
        }

    }
}

