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
        [Route("")]
        public List<BandDTO> ListaBands()
        {
            return new BandService().GetBands();
        }

        

        

        

    }
}

