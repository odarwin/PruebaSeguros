using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectChubb.Models
{
    public partial class Venta
    {
        public int IdVenta { get; set; }
        public int? IdSeguroVenta { get; set; }
        public int? IdPersona { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? IdRangoVenta { get; set; }
        public decimal? ValorVenta { get; set; }
        public int? IdPorcentajeVenta { get; set; }
        public decimal? Prima { get; set; }
    }
}
