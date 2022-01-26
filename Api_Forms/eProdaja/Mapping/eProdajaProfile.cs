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
        public eProdajaProfile()
        {
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

            CreateMap<ProizvodKomentari, ProizvodKomentarResponse>()
                .ForMember(dest => dest.Id,
                obj => obj.MapFrom(src => src.ProizvodKomentarId))
                .ForMember(dest => dest.KupacImePrezime,
                obj => obj.MapFrom(src => $"{src.Kupac.Ime} {src.Kupac.Prezime}"))
                .ForMember(dest => dest.ProizvodNaziv,
                obj => obj.MapFrom(src => src.Proizvod.Naziv));


            CreateMap<ProizvodKomentarInsertRequest, ProizvodKomentari>();
        }
    }
}
