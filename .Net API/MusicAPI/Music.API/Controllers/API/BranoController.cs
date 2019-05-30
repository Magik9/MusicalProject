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
        private BranoService _branoService { get; set; }

        public BranoController(BranoService service)
        {
            _branoService = service;
        }

        [HttpGet]
        [Route("{id:int}")]
        public BranoDTO Brano(int id)
        {
            return _branoService.GetSingleBrano(id);
        }

        [HttpGet]
        [Route("")]
        public List<BranoDTO> ListaBrani()
        {
            return _branoService.GetBrani();
        }

        [HttpGet]
        [Route("Disco/{id:int}")]
        public List<BranoDTO> BraniDisco(int id)
        {
            return _branoService.GetBraniDisco(id);
        }

        [HttpPost]
        [Route("Add")]
        public void AddBrano(BranoDTO bdto)
        {
            _branoService.SaveNewBrano(bdto);
        }

        [HttpPut]
        [Route("Update")]
        public void UpdateBrano(BranoDTO updated)
        {
            _branoService.UpdateSingleBrano(updated);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public void DeleteBrano(int id)
        {
            _branoService.DeleteSingleBrano(id);
        }

    }
}
