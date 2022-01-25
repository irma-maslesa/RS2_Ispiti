using System;
using System.Collections.Generic;


namespace eProdaja.Model
{
    public partial class NarudzbaPasos
    {
        public int NarudzbaId { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public decimal Cijena { get; set; }
        public bool VazeciPasos { get; set; }
    }
}
