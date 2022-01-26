using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class PretragaIspit
    {
        public int PretragaIspitId { get; set; }
        public int VrstaProizvodaId { get; set; }
        public int KorisnikId { get; set; }
        public double MinIznos { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DaumDo { get; set; }
        public double Iznos { get; set; }

        public virtual Korisnici Korisnik { get; set; }
        public virtual VrsteProizvodum VrstaProizvoda { get; set; }
    }
}
