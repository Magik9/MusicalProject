﻿using Music.BLL.DTO;
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

        public BandController(BandService service)
        {
            _bandService = service;
        }

        [HttpGet]
        [Route("")]
        public List<BandDTO> ListaBands()
        {
            return _bandService.GetBands();
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public void DeleteSingleBand(int id)
        {
            _bandService.DeleteBand(id);
        }







    }
}

