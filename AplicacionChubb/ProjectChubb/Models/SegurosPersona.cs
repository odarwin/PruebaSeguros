using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectChubb.Models
{
    public partial class SegurosPersona
    {
        public decimal IdSeguro { get; set; }
        public int IdPersona { get; set; }
        public decimal IdSeguroPersona { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Seguro IdSeguroNavigation { get; set; }
    }
}
