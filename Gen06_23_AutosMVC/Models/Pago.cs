using System;
using System.Collections.Generic;

namespace Gen06_23_AutosMVC.Models
{
    public partial class Pago
    {
        public int Id { get; set; }
        public string Monto { get; set; }
        public int NumPago { get; set; }
        public int PerfilId { get; set; }
        public int AutoId { get; set; }
        public int StatusPagoId { get; set; }
        public int CostoAdicionalId { get; set; }
        public int? TipoPagoId { get; set; }

        public virtual Auto Auto { get; set; }
        public virtual CostoAdicional CostoAdicional { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual StatusPago StatusPago { get; set; }
        public virtual TipoPago TipoPago { get; set; }
    }
}
