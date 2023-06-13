using System;
using System.Collections.Generic;

namespace Gen06_23_AutosMVC.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            Pagos = new HashSet<Pago>();
            Renta = new HashSet<Rentum>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Rentum> Renta { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
