using System;
using System.Collections.Generic;

namespace Gen06_23_AutosMVC.Models
{
    public partial class Auto
    {
        public Auto()
        {
            Pagos = new HashSet<Pago>();
            Renta = new HashSet<Rentum>();
        }

        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public double Costo { get; set; }
        public string Color { get; set; }
        public string Urlfoto { get; set; }
        public int StatusAutoId { get; set; }

        public virtual StatusAuto StatusAuto { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Rentum> Renta { get; set; }
    }
}
