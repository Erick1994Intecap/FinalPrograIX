using System;
using System.Collections.Generic;

#nullable disable

namespace ApiRestHoovers.Models
{
    public partial class VehiculoResult
    {
        public int Id { get; set; }
        public int? Modelo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }
    }
}
