using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso.Datos;
using Acceso.Entidad;

namespace Acceso.Negocio
{
    public class UsuarioBL
    {
        public async Task<IEnumerable<Usuario>> UsuarioObtener(string email)
        {
            return await new UsuarioDA().UsuarioObtener(email);
        }

        public async Task<IEnumerable<String>> SedeObtener()
        {
            return await new UsuarioDA().SedeObtener();
        }
        public async Task<IEnumerable<String>> EspecialidadObtener()
        {
            return await new UsuarioDA().EspecialidadObtener();
        }
    }
}
