using System;
using System.Collections.Generic;

namespace Gen06_23_AutosMVC.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PerfilId { get; set; }
        public int DomicilioId { get; set; }
        public int DatosPersonalesId { get; set; }

        public virtual DatosPersonale DatosPersonales { get; set; }
        public virtual Domicilio Domicilio { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
