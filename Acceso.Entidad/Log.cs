using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso.Entidad
{
    public class Log
    {
        public int idlog { get; set; }
        public Usuario usuario { get; set; }
        public string uscre { get; set; }
        public DateTime? fecre { get; set; }
        public int flactivo { get; set; }
    }
}
