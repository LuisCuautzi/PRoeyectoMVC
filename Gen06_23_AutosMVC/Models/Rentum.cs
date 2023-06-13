using System;
using System.Collections.Generic;

namespace Gen06_23_AutosMVC.Models
{
    public partial class Rentum
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int DatosPersonalesId { get; set; }
        public int PerfilId { get; set; }
        public int AutoId { get; set; }
        public int StatusRentaId { get; set; }

        public virtual Auto Auto { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual StatusRentum StatusRenta { get; set; }
    }
}
