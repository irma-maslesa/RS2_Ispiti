using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using eProdaja.Model;
using eProdaja.Model.Requests;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class ProizvodKomentariController
    {
        protected readonly IProizvodKomentarService Service;

        public ProizvodKomentariController(IProizvodKomentarService service)
        {
            Service = service;
        }


        [HttpGet]
        public virtual IEnumerable<ProizvodKomentarResponse> Get()
        {
            return Service.Get();
        }

        [HttpGet("search")]
        public virtual IEnumerable<ProizvodKomentarResponse> Search([FromQuery] ProizvodKomentarSearchRequest search) {
            return Service.Search(search);
        }

        [HttpPost]
        public ProizvodKomentarResponse Insert([FromBody] ProizvodKomentarInsertRequest request) {
            return Service.Insert(request);
        }
    }
}
