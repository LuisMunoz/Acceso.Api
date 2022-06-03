using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Acceso.Entidad;
using Acceso.Negocio;

namespace Acceso.WebApi.Controllers
{
    [RoutePrefix("api/Sistema")]
    public class SistemaController : ApiController
    {
        #region  Estudiante

        private LogBL logService = new LogBL();

        [HttpGet]
        [Route("Registro/{id}")]
        public async Task<IEnumerable<Usuario>> ListarLog(int id) => await logService.ListarLog(id);

        [HttpPost]
        [Route("Registro")]
        public async Task<int> RegistrarLog([FromBody] Usuario input)
        {
            input.fecre = DateTime.Now;
            return await logService.RegistrarLog(input);
        }

        [HttpGet]
        [Route("Registro/{sede}/{especialidad}")]
        public async Task<IEnumerable<Usuario>> ListarLogFiltro(string sede,string especialidad) => await logService.ListarLogFiltro(sede,especialidad);


        private UsuarioBL usService = new UsuarioBL();

        [HttpPost]
        [Route("Usuario")]
        public async Task<IEnumerable<Usuario>> ObtenerUsuario([FromBody] Usuario input) {
            return await usService.UsuarioObtener(input.email);
        }

        [HttpGet]
        [Route("Sede")]
        public async Task<IEnumerable<String>> ListarSede() => await usService.SedeObtener();

        [HttpGet]
        [Route("Especialidad")]
        public async Task<IEnumerable<String>> ListaEspecialidad() => await usService.EspecialidadObtener();

        #endregion

        #region Administrador

        private RequisitoBL reqService = new RequisitoBL();

        [HttpGet]
        [Route("Requisito")]
        public async Task<IEnumerable<Requisito>> ListarRequisito() => await reqService.ListarRequisito();

        [HttpPost]
        [Route("Requisito")]
        public async Task<bool> RegistrarRequisito([FromBody] Requisito input)
        {
            input.fecre = DateTime.Now;

            return await reqService.RegistrarRequisito(input);
        }

        [HttpPatch]
        [Route("Requisito/{id}")]
        public async Task<IHttpActionResult> ActualizarRequisito(int id, [FromBody] Requisito input)
        {
            if (id == 0 || id != input.idrequisito)
            {
                return BadRequest("No se pudo actualizar el requisito");
            }
            input.femod = DateTime.Now;

            return Ok(await reqService.ActualizarRequisito(input));
        }
        
        #endregion

        #region Seguridad

        #endregion


    }
}