using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M151_Eisstand.Modell
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Bez { get; set; }
        public int Preis { get; set; }
        public int fk_kugeln { get; set; }
    }
}
