using Music.BLL.DTO;
using Music.BLL.BL;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Music.Controllers.API
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("Music")]
    public class MusicController : ApiController
    {
        [HttpGet]
        [Route("Brano")]
        public BranoDTO Brano(int id)
        {
            return new WebAPILogic().GetSingleBrano(id);
        }

        [HttpGet]
        [Route("Brani-Disco")]
        public List<BranoDTO> BraniDisco(int id)
        {
            return new WebAPILogic().GetBraniDisco(id);
        }

        [HttpGet]
        [Route("Bands")]
        public List<BandDTO> ListaBands()
        {
            return new WebAPILogic().GetBands();
        }

        [HttpGet]
        [Route("Dischi")]
        public List<DiscoDTO> ListaDischi()
        {
            return new WebAPILogic().GetDischi();
        }

        [HttpGet]
        [Route("Brani")]
        public List<BranoDTO> ListaBrani()
        {
            return new WebAPILogic().GetBrani();
        }

        [HttpPost]
        [Route("AddBrano")]
        public void AddBrano(BranoDTO bdto)
        {
            new WebAPILogic().SaveNewBrano(bdto);
        }

        [HttpDelete]
        [Route("DeleteBrano")]
        public void DeleteBrano(int id)
        {
            new WebAPILogic().DeleteSingleBrano(id);
        }

        [HttpPut]
        [Route("UpdateBrano")]
        public void UpdateBrano(BranoDTO updated)
        {
            new WebAPILogic().UpdateSingleBrano(updated);
        }

    }
}

