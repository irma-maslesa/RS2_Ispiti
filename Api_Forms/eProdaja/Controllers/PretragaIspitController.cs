using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using eProdaja.Model;
using eProdaja.Model.Requests;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class PretragaIspitController
    {
        protected readonly IPretragaIspitService _service;

        public PretragaIspitController(IPretragaIspitService service)
        {
            _service = service;
        }


        [HttpGet]
        public virtual IEnumerable<PretragaIspitResponse> Get([FromQuery] PretragaIspitSearchRequest search)
        {
            return _service.Get(search);
        }

        [HttpGet("zapisi")]
        public virtual IEnumerable<PretragaIspitResponse> GetZapise([FromQuery] int korisnikId) {
            return _service.GetZapise(korisnikId);
        }

        [HttpPost]
        public PretragaIspitResponse Insert([FromBody] PretragaIspitInsertRequest request) {
            return _service.Insert(request);
        }
    }
}
