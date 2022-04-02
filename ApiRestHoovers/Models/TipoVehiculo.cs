using System;
using System.Collections.Generic;

#nullable disable

namespace ApiRestHoovers.Models
{
    public partial class TipoVehiculo
    {
        public TipoVehiculo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
