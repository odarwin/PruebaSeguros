using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectChubb.Models
{
    public partial class Seguro
    {
        public Seguro()
        {
            SegurosPersonas = new HashSet<SegurosPersona>();
        }

        public string NombreSeguro { get; set; }
        public decimal IdSeguro { get; set; }
        public string CodigoSeguro { get; set; }
        public decimal ValorSeguro { get; set; }
        public decimal Prima { get; set; }
        public DateTime FechaCreacionSeguro { get; set; }
        public DateTime FechaModificacionSeguro { get; set; }
        public string RangoEdadSeguro { get; set; }
        public string PorcentajeSeguro { get; set; }
        public int? IdTipoSeguro { get; set; }
        public int? EstadoSeguro { get; set; }

        public virtual ICollection<SegurosPersona> SegurosPersonas { get; set; }
    }
}
