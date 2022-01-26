using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.Requests
{
    public partial class PretragaIspitInsertRequest {
        public int VrstaProizvodaId { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public decimal MinIznos { get; set; }
        public List<PretragaIspitResponse> Korisnici { get; set; }
    }
}
