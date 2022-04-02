using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestHoovers.Models
{
    public class ReporteVista
    {
        public String NOMBRE { get; set; }
        public String TELEFONO { get; set; }
        public String ID { get; set; }
        public int ID_CLIENTE { get; set; }
        public int ID_VEHICULO { get; set; }
        public String FECHA_VIAJE { get; set; }
        public String FECHA_FIN { get; set; }
        public float PRECIO_VIAJE { get; set; }
        public int ID_DEPTO_VIAJE { get; set; }
        public String DESCRIPCION_VIAJE { get; set; }
        public int VIAJE_REALIZADO { get; set; }
        
    }
}
