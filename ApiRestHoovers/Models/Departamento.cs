using System;
using System.Collections.Generic;

#nullable disable

namespace ApiRestHoovers.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
