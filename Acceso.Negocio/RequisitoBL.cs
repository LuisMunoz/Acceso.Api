using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso.Entidad;
using Acceso.Datos;

namespace Acceso.Negocio
{
    public class RequisitoBL
    {
        public async Task<IEnumerable<Requisito>> ListarRequisito()
        {
            return await new RequisitoDA().ListaRequisito();
        }
        public async Task<bool> RegistrarRequisito(Requisito input)
        {
            return await new RequisitoDA().RegistrarRequisito(input);
        }
        public async Task<bool> ActualizarRequisito(Requisito input)
        {
            return await new RequisitoDA().ActualizarRequisito(input);
        }

    }
}
