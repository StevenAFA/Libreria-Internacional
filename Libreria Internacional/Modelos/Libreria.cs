using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libreria_Internacional.Modelos
{
    public class Libreria
    {
        public int ISBN { get; set; }
        public string nombreLibro { get; set; }
        public string autorLibro { get; set; }
        public string Foto { get; set; }
        public decimal Precio { get; set; }
    }
}