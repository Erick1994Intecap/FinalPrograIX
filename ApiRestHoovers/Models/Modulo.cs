using System;
using System.Collections.Generic;

#nullable disable

namespace ApiRestHoovers.Models
{
    public partial class Modulo
    {
        public Modulo()
        {
            Bitacoras = new HashSet<Bitacora>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Bitacora> Bitacoras { get; set; }
    }
}
