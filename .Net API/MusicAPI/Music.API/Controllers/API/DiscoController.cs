using Music.BLL.BL;
using Music.BLL.BO;
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

        public DiscoController(DiscoService discoService)
        {
            _discoService = discoService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public DiscoDTO Disco(int id)
        {
            return _discoService.GetDisco(id);
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

        [HttpPut]
        [Route("Update")]
        public void UpdateDisco(DiscoBO discoBO)
        {
            _discoService.UpdateDisco(discoBO);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public void DeleteSingleDisco(int id)
        {
            _discoService.DeleteDisco(id);
        }
    }
}
