using System;
using System.Collections.Generic;

#nullable disable

namespace ApiRestHoovers.Models
{
    public partial class MetodoHttp
    {
        public MetodoHttp()
        {
            Bitacoras = new HashSet<Bitacora>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Bitacora> Bitacoras { get; set; }
    }
}
