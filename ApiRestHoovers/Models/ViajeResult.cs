using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestHoovers.Models
{
    public class ViajeResult
    {
        public int? Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVehiculo { get; set; }
        public decimal? PrecioViaje { get; set; }
        public int? IdDeptoViaje { get; set; }
        public string DescripcionViaje { get; set; }
        public int? ViajeRealizado { get; set; }

    }
}
