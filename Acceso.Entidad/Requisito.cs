using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso.Entidad
{
    public class Requisito
    {
        public int idrequisito { get; set; }
        public string descripcion { get; set; }
        public bool flactivo { get; set; }
        public string uscre { get; set; }
        public DateTime? fecre { get; set; }
        public string usmod { get; set; }
        public DateTime? femod { get; set; }
        public DateTime? feini { get; set; }
        public DateTime? fefin { get; set; }

        public bool flseleccion { get; set; }
    }
}
