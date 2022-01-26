using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public partial class PretragaIspitExtendedResponse:PretragaIspitResponse
    {
        public int VrstaProizvodaId { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public decimal MinIznos { get; set; }
        public decimal ProsjecanPromet { get; set; }
    }
}
