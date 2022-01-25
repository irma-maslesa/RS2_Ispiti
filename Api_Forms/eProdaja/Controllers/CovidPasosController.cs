using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CovidPasosController
    {
        private readonly ICovidPasosService Service;

        public CovidPasosController(ICovidPasosService service)
        {
            Service = service;
        }

        [HttpGet]
        public IEnumerable<CovidPasos> Get() {
            return Service.Get();
        }

        [HttpGet("kupci")]
        public IEnumerable<LoV> GetKupce() {
            return Service.GetKupce();
        }

        [HttpPost]
        public CovidPasos Insert([FromBody] CovidPasosInsertRequest request) {
            return Service.Insert(request);
        }

        [HttpGet("narudzbe")]
        public IEnumerable<NarudzbaPasos> GetNarudzbe([FromQuery] CovidPasosSearchRequest search) {
            return Service.GetNarudzbe(search);
        }

    }
}
