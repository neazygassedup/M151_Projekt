using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M151_Eisstand.Modell
{
    public class Bestellung
    {
        public int Id { get; set; }
        public int fk_benutzer { get; set; }
        public int fk_produkt { get; set; }
    }
}
