using System;
using System.Collections.Generic;

namespace Gen06_23_AutosMVC.Models
{
    public partial class CostoAdicional
    {
        public CostoAdicional()
        {
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public string MontoAdicional { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
