using Music.BLL.BL;
using Music.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Music.API.Controllers.API
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("Dischi")]
    public class DiscoController : ApiController
    {
        private DiscoService _discoService = null;

        public DiscoController(DiscoService service)
        {
            _discoService = service;
        }

        [HttpGet]
        [Route("")]
        public List<DiscoDTO> ListaDischi()
        {
            return _discoService.GetDischi();
        }

        [HttpGet]
        [Route("Band/{id:int}")]
        public List<DiscoDTO> ListaDischi(int id)
        {
            return _discoService.GetDischiBand(id);
        }
    }
}
