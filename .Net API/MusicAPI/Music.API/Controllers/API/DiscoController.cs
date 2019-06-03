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
        [HttpGet]
        [Route("{id:int}")]
        public DiscoDTO Disco(int id)
        {
            return DiscoService.GetSingleDisco(id);
        }

        [HttpGet]
        [Route("")]
        public List<DiscoDTO> ListaDischi()
        {
            return DiscoService.GetDischi();
        }

        [HttpGet]
        [Route("Band/{id:int}")]
        public List<DiscoDTO> ListaDischi(int id)
        {
            return DiscoService.GetDischiBand(id);
        }

        [HttpPut]
        [Route("Update")]
        public void UpdateDisco(DiscoDTO discoDTO)
        {
            DiscoService.UpdateDisco(discoDTO);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public void DeleteSingleDisco(int id)
        {
            DiscoService.DeleteDisco(id);
        }
    }
}
