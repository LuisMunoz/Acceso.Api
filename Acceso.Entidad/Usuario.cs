using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso.Entidad
{
    public class Usuario
    {
        public int idusuario { get; set; }
        public string nombres { get; set; }
        public string apepa { get; set; }
        public string apema { get; set; }
        public DateTime? fecnac { get; set; }
        public string sede { get; set; }
        public string especialidad { get; set; }
        public DateTime? feing { get; set; }
        public string uscre { get; set; }
        public DateTime? fecre { get; set; }
        public int genero { get; set; }
        public int tipodoc { get; set; }
        public string nrodoc { get; set; }
        public string email { get; set; }
        public int idrol { get; set; }

        public int idlog { get; set; }
        public bool flactivo { get; set; }
    }
}
