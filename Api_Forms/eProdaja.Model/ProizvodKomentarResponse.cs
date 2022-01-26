using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public class ProizvodKomentarResponse
    {
        public int Id { get; set; }
        public string Komentar { get; set; }
        public string KupacImePrezime { get; set; }
        public DateTime Datum { get; set; }
        public int BrojRijeci { get; set; }
        public string ProizvodNaziv { get; set; }
    }
}
