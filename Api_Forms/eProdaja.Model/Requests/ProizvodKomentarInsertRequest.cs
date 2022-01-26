using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.Requests
{
    public class ProizvodKomentarInsertRequest
    {
        public string Komentar { get; set; }
        public int KupacId { get; set; }
        public DateTime Datum { get; set; }
        public int ProizvodId { get; set; }
    }
}
