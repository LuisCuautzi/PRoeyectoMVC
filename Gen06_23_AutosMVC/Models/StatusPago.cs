using System;
using System.Collections.Generic;

namespace Gen06_23_AutosMVC.Models
{
    public partial class StatusPago
    {
        public StatusPago()
        {
            Pagos = new HashSet<Pago>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
