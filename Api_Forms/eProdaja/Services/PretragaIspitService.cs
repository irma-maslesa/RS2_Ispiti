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
    public class PretragaIspitService:IPretragaIspitService
    {
        public eProdajaContext Context { get; set; }
        protected readonly IMapper _mapper;

        public PretragaIspitService(eProdajaContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public IEnumerable<PretragaIspitResponse> Get(PretragaIspitSearchRequest search) {
            var izlazi = Context.Izlazis
                .Include(e => e.IzlazStavkes)
                    .ThenInclude(e => e.Proizvod)
                .Include(e => e.Korisnik)
                .Where(e => e.Datum >= search.DatumOd)
                .Where(e => e.Datum <= search.DatumDo)
                .ToList();

            var izlaziPoKorisniku = izlazi.GroupBy(e => e.KorisnikId);

            var response = new List<PretragaIspitResponse>();

            foreach (var korisnik in izlaziPoKorisniku) {
                if(korisnik.Sum(e => e.IznosSaPdv) >= search.MinIznos && 
                    korisnik.Select(e => e.IzlazStavkes).SelectMany(e => e).Select(e => e.Proizvod.VrstaId).Contains(search.VrstaProizvodaId)) {
                    response.Add(new PretragaIspitResponse {
                        KorisnikId = korisnik.Key,
                        KorisnikImePrezime = korisnik.Select(e => $"{e.Korisnik.Ime} {e.Korisnik.Prezime}").FirstOrDefault(),
                        Iznos = korisnik.Select(e => e.IznosSaPdv).Sum()
                    });
                }
            }

            return response;
        }

        public IEnumerable<PretragaIspitExtendedResponse> GetZapise(int korisnikId) {
            var zapisi = Context.PretragaIspits.Where(e => e.KorisnikId == korisnikId).Include(e => e.Korisnik).ToList();

            var response = new List<PretragaIspitExtendedResponse>();
            foreach (var e in zapisi) 
            {
                var izlazi = Context.Izlazis.ToList();
                response.Add(new PretragaIspitExtendedResponse {
                    MinIznos = (decimal)e.MinIznos,
                    DatumOd = e.DatumOd,
                    DatumDo = e.DaumDo,
                    Iznos = (decimal)e.Iznos,
                    VrstaProizvodaId = e.VrstaProizvodaId,
                    KorisnikId = e.KorisnikId,
                    KorisnikImePrezime = $"{e.Korisnik.Ime} {e.Korisnik.Prezime}",
                    ProsjecanPromet = izlazi.Average(e => e.IznosSaPdv)                
                });
            }

            return response;
        }

        public PretragaIspitResponse Insert(PretragaIspitInsertRequest request) {
            if (Context.VrsteProizvoda.Find(request.VrstaProizvodaId) == null)
                throw new UserException("Vrsta proizvoda ne postoji");

            var entites = new List<PretragaIspit>();

            foreach (var e in request.Korisnici) {
                if (Context.Korisnicis.Find(e.KorisnikId) == null)
                    throw new UserException("Korisnik ne postoji");

                entites.Add(new PretragaIspit {
                    DatumOd = request.DatumOd,
                    DaumDo = request.DatumDo,
                    MinIznos = (double)request.MinIznos,
                    Iznos = (double)e.Iznos,
                    KorisnikId = e.KorisnikId,
                    VrstaProizvodaId = request.VrstaProizvodaId
                });
            }

            Context.AddRange(entites);

            return new PretragaIspitResponse();
        }
    }
}
