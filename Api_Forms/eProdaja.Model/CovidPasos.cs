using System;
using System.Collections.Generic;

namespace eProdaja.Model
{
    public partial class CovidPasos
    {
        public int CovidPasosId { get; set; }
        public int? KupacId { get; set; }
        public string KupacImePrezime { get; set; }
        public DateTime? DatumIzdavanja { get; set; }
        public DateTime? DatumVazenja { get; set; }

    }
}
