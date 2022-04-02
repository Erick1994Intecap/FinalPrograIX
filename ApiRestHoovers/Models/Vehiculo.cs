using System;
using System.Collections.Generic;

#nullable disable

namespace ApiRestHoovers.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int Id { get; set; }
        public int? Modelo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdTipo { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual TipoVehiculo IdTipoNavigation { get; set; }
        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
