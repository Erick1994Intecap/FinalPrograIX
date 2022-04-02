using System;
using System.Collections.Generic;

#nullable disable

namespace ApiRestHoovers.Models
{
    public partial class Viaje
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVehiculo { get; set; }
        public DateTime? FechaViaje { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? PrecioViaje { get; set; }
        public int? IdDeptoViaje { get; set; }
        public string DescripcionViaje { get; set; }
        public int? ViajeRealizado { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Departamento IdDeptoViajeNavigation { get; set; }
        public virtual Vehiculo IdVehiculoNavigation { get; set; }
    }
}
