using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class CovidPasosi
    {
        public int CovidPasosId { get; set; }
        public int? KupacId { get; set; }
        public DateTime? DatumIzdavanja { get; set; }
        public DateTime? DatumVazenja { get; set; }

        public virtual Kupci Kupac { get; set; }
    }
}
