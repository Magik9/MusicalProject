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
        private BandService _bandService = null;

        public BandController(BandService bandService)
        {
            _bandService = bandService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public BandDTO Band(int id)
        {
            return _bandService.GetBand(id);
        }

        [HttpGet]
        [Route("")]
        public List<BandDTO> ListaBands()
        {
            return _bandService.GetBands();
        }

        [HttpPut]
        [Route("Update")]
        public void UpdateBand(BandDTO bandDTO)
        {
            _bandService.UpdateBand(bandDTO);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public void DeleteSingleBand(int id)
        {
            _bandService.DeleteBand(id);
        }

    }
}

