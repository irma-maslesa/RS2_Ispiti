using AutoMapper;
using eProdaja.Database;
using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Mapping
{
    public class eProdajaProfile : Profile
    {
        public eProdajaProfile() {
            CreateMap<Database.Korisnici, Model.Korisnici>();
            CreateMap<Database.JediniceMjere, Model.JediniceMjere>();
            CreateMap<Database.VrsteProizvodum, Model.VrsteProizvodum>();
            CreateMap<Database.Proizvodi, Model.Proizvodi>();
            CreateMap<Database.Uloge, Model.Uloge>();
            CreateMap<Database.KorisniciUloge, Model.KorisniciUloge>();
            CreateMap<ProizvodiInsertRequest, Database.Proizvodi>();
            CreateMap<ProizvodiUpdateRequest, Database.Proizvodi>();
            CreateMap<KorisniciInsertRequest, Database.Korisnici>();
            CreateMap<KorisniciUpdateRequest, Database.Korisnici>();


            CreateMap<CovidPasosi, CovidPasos>().ForMember(dest =>
                dest.KupacImePrezime,
                src => src.MapFrom(
                    e => $"{e.Kupac.Ime} {e.Kupac.Prezime}"
                )
            );
            CreateMap<CovidPasosInsertRequest, CovidPasosi>();
            CreateMap<Kupci, LoV>().ForMember(dest =>
               dest.Naziv,
                src => src.MapFrom(
                    e => $"{e.Ime} {e.Prezime}"
                )
            ).ForMember(dest =>
                dest.Id,
                src => src.MapFrom(
                    e => e.KupacId
                )
            );
        }
    }
}
