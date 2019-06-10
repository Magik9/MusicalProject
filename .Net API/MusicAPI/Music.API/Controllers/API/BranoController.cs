using Music.BLL.BL;
using Music.BLL.BO;
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
        private BranoService _branoService = null;

        public BranoController(BranoService branoService)
        {
            _branoService = branoService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public BranoDTO Brano(int id)
        {
            return _branoService.GetBrano(id);
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
        public void AddBrano(BranoBO branoBO)
        {
            _branoService.AddNewBrano(branoBO);
        }

        [HttpPut]
        [Route("Update")]
        public void UpdateBrano(BranoBO branoBO)
        {
            _branoService.UpdateBrano(branoBO);
            
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public void DeleteBrano(int id)
        {
            _branoService.DeleteBrano(id);
        }

    }
}
