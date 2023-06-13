using System;
using System.Collections.Generic;

namespace Gen06_23_AutosMVC.Models
{
    public partial class Domicilio
    {
        public Domicilio()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Calle { get; set; }
        public string NumeroInt { get; set; }
        public string NumeroExt { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string Ciudad { get; set; }
        public string Cp { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
