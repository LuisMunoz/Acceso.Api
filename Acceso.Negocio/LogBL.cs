using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso.Entidad;
using Acceso.Datos;

namespace Acceso.Negocio
{
    public class LogBL
    {
        public async Task<IEnumerable<Usuario>> ListarLog(int id)
        {
            return await new LogDA().ListaLog(id);
        }
        public async Task<int> RegistrarLog(Usuario input)
        {
            try
            {
                return await new LogDA().RegistrarLog(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<IEnumerable<Usuario>> ListarLogFiltro(string sede,string especialidad)
        {
            return await new LogDA().ListaLogFiltro(sede,especialidad);
        }
    }
}
