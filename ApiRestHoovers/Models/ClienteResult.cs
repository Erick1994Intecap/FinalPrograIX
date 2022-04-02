using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestHoovers.Models
{
    public class ClienteResult
    {
        public int? Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Telefono { get; set; }
        public int? Estado { get; set; }
    }
}
