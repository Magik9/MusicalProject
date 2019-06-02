using Music.BLL.BL;
using Music.BLL.DTO;
using System.Collections.Generic;

using System.Web.Http;
using System.Web.Http.Cors;

namespace Music.API.Controllers.API
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("Brani")]
    public class BranoController : ApiController
    {
        [HttpGet]
        [Route("{id:int}")]
        public BranoDTO Brano(int id)
        {
            return BranoService.GetSingleBrano(id);
        }

        [HttpGet]
        [Route("")]
        public List<BranoDTO> ListaBrani()
        {
            return BranoService.GetBrani();
        }

        [HttpGet]
        [Route("Disco/{id:int}")]
        public List<BranoDTO> BraniDisco(int id)
        {
            return BranoService.GetBraniDisco(id);
        }

        [HttpPost]
        [Route("Add")]
        public void AddBrano(BranoDTO bdto)
        {
            BranoService.SaveNewBrano(bdto);
        }

        [HttpPut]
        [Route("Update")]
        public void UpdateBrano(BranoDTO updated)
        {
            BranoService.UpdateSingleBrano(updated);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public void DeleteBrano(int id)
        {
            BranoService.DeleteSingleBrano(id);
        }

    }
}
