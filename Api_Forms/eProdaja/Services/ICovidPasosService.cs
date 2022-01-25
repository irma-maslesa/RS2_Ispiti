using eProdaja.Database;
using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface ICovidPasosService
    {
        IEnumerable<CovidPasos> Get();
        IEnumerable<NarudzbaPasos> GetNarudzbe(CovidPasosSearchRequest search);

        CovidPasos Insert(CovidPasosInsertRequest request);
        IEnumerable<LoV> GetKupce();
    }
}
