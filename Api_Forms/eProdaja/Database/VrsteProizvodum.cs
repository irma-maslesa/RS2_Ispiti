using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class VrsteProizvodum
    {
        public VrsteProizvodum()
        {
            PretragaIspits = new HashSet<PretragaIspit>();
            Proizvodis = new HashSet<Proizvodi>();
        }

        public int VrstaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<PretragaIspit> PretragaIspits { get; set; }
        public virtual ICollection<Proizvodi> Proizvodis { get; set; }
    }
}
