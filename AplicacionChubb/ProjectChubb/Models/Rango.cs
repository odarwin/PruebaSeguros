using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectChubb.Models
{
    public partial class Rango
    {
        public int IdRango { get; set; }
        public decimal? Inicio { get; set; }
        public decimal? Fin { get; set; }
        public decimal? Porcentaje { get; set; }
    }
}
