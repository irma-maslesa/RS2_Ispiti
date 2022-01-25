using AutoMapper;
using eProdaja.Database;
using eProdaja.Filters;
using eProdaja.Model;
using eProdaja.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class CovidPasosService : ICovidPasosService
    {
        public eProdajaContext Context { get; set; }
        protected readonly IMapper _mapper;

        public CovidPasosService(eProdajaContext context, IMapper mapper){
            Context = context;
            _mapper = mapper;
        }

        public IEnumerable<Model.CovidPasos> Get() {
            var entities = Context.Set<Database.CovidPasosi>().Include(e => e.Kupac).ToList();

            return _mapper.Map<List<Model.CovidPasos>>(entities);
        }

        public CovidPasos Insert(CovidPasosInsertRequest request) {
            if (Context.Kupcis.Find(request.KupacId) == null)
                throw new UserException("Kupac ne postoji");

            CovidPasosi entity = _mapper.Map<CovidPasosi>(request);

            Context.Add(entity);

            Context.SaveChanges();

            return _mapper.Map<CovidPasos>(entity);
        }

        public IEnumerable<NarudzbaPasos> GetNarudzbe(CovidPasosSearchRequest search) {
            var narudzbe = Context.Narudzbes.Include(e => e.NarudzbaStavkes).ThenInclude(e => e.Proizvod).AsQueryable();
            
            if (search.KupacId.HasValue) {
                narudzbe = narudzbe.Where(x => x.KupacId == search.KupacId);
            }

            if (search.DatumOd.HasValue) {
                narudzbe = narudzbe.Where(x => x.Datum >= search.DatumOd.Value);
            }

            if (search.DatumDo.HasValue) {
                narudzbe = narudzbe.Where(x => x.Datum <= search.DatumDo.Value);
            }

            List<NarudzbaPasos> narudzbeResponse = new List<NarudzbaPasos>();

            narudzbe.ToList().ForEach(e => {
                narudzbeResponse.Add(new NarudzbaPasos {
                    NarudzbaId = e.NarudzbaId,
                    BrojNarudzbe = e.BrojNarudzbe,
                    Datum = e.Datum,
                    Cijena = getUkupnaCijena(e),
                    VazeciPasos = imaVazeciPasos(e.KupacId, e.Datum)
                });
            
            });

            return narudzbeResponse;
        }

        private bool imaVazeciPasos(int kupacId, DateTime datum) {

            var pasosi = Context.Set<Database.CovidPasosi>().Where(e => e.KupacId == kupacId).ToList();

            foreach (var pasos in pasosi) {
                if (datum >= pasos.DatumIzdavanja && datum <= pasos.DatumVazenja)
                    return true;
            }

            return false;
        }

        private decimal getUkupnaCijena(Narudzbe e) {
            decimal suma = 0;

            e.NarudzbaStavkes.ToList().ForEach(e => suma += e.Kolicina * e.Proizvod.Cijena);

            return suma;
        }

        public IEnumerable<LoV> GetKupce() {

            var entities = Context.Set<Database.Kupci>().ToList();

            return _mapper.Map<List<Model.LoV>>(entities);
        }
    }
}
