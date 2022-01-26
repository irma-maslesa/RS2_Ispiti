using AutoMapper;
using eProdaja.Database;
using eProdaja.Filters;
using eProdaja.Model;
using eProdaja.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eProdaja.Services
{
    public class ProizvodKomentarService : IProizvodKomentarService
    {
        public eProdajaContext Context { get; set; }
        protected readonly IMapper Mapper;

        public ProizvodKomentarService(eProdajaContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        public IEnumerable<ProizvodKomentarResponse> Get() {
            var entites = Context.ProizvodKomentaris
                .Include(e => e.Kupac)
                .Include(e => e.Proizvod)
                .ToList();

            return Mapper.Map<List<ProizvodKomentarResponse>>(entites);
        }

        public IEnumerable<ProizvodKomentarResponse> Search(ProizvodKomentarSearchRequest search) {

            var entites = Context.ProizvodKomentaris
                            .Include(e => e.Kupac)
                            .Include(e => e.Proizvod)
                            .AsQueryable();

            if (search.ProizvodId.HasValue) {
                entites = entites.Where(x => x.ProizvodId == search.ProizvodId.Value);
            }

            if (search.DatumOd.HasValue) {
                entites = entites.Where(x => x.Datum >= search.DatumOd.Value);
            }

            if (search.DatumDo.HasValue) {
                entites = entites.Where(x => x.Datum <= search.DatumDo.Value);
            }

            var response = Mapper.Map<List<ProizvodKomentarResponse>>(entites);

            response.ForEach(e => e.BrojRijeci = e.Komentar.Split(" ").Length);

            return response;
        }

        public ProizvodKomentarResponse Insert(ProizvodKomentarInsertRequest request) {
            if (Context.Kupcis.Find(request.KupacId) == null)
                throw new UserException("Kupac ne postoji");

            if (Context.Proizvodis.Find(request.ProizvodId) == null)
                throw new UserException("Proizvod ne postoji");


            ProizvodKomentari entity = Mapper.Map<ProizvodKomentari>(request);

            Context.Add(entity);

            Context.SaveChanges();

            return Mapper.Map<ProizvodKomentarResponse>(entity);
        }
    }
}
