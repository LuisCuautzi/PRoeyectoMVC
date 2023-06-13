using System;
using System.Collections.Generic;

namespace Gen06_23_AutosMVC.Models
{
    public partial class StatusRentum
    {
        public StatusRentum()
        {
            Renta = new HashSet<Rentum>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Rentum> Renta { get; set; }
    }
}
