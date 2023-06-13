using System;
using System.Collections.Generic;

namespace Gen06_23_AutosMVC.Models
{
    public partial class StatusAuto
    {
        public StatusAuto()
        {
            Autos = new HashSet<Auto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Auto> Autos { get; set; }
    }
}
