using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectChubb.Models
{
    public partial class Persona
    {
        public Persona()
        {
            SegurosPersonas = new HashSet<SegurosPersona>();
        }
        [Display(Name = "ID")]

        public int IdPersona { get; set; }
        [Display(Name = "Nombre")]

        public string NombrePersona { get; set; }
        [Display(Name = "Apellido")]

        public string ApellidoPersona { get; set; }
        [Display(Name = "Cedula")]

        public string CedulaPersona { get; set; }
        [Display(Name = "Telefono")]

        public string TelefonoPersona { get; set; }
        [Display(Name = "Estado")]

        public int EstadoPersona { get; set; }

        public virtual ICollection<SegurosPersona> SegurosPersonas { get; set; }
    }
}
