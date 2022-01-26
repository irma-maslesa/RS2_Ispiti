using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public partial class PretragaIspitResponse
    {
        public int KorisnikId { get; set; }
        public string KorisnikImePrezime { get; set; }
        public decimal Iznos { get; set; }
    }
}
