using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Acceso.Entidad;

namespace Acceso.Datos
{
    public class UsuarioDA
    {

        public async Task<IEnumerable<Usuario>> UsuarioObtener(string email)
        {
            IEnumerable<Usuario> usuario = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["condev"].ConnectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@email", email);

                usuario = await connection.QueryAsync<Usuario>("[dbo].[usp_Usuario_Obtener]", parametros, commandType: CommandType.StoredProcedure).ConfigureAwait(true);
                connection.Close();
            }
            return usuario;
        }

        public async Task<IEnumerable<String>> SedeObtener()
        {
            IEnumerable<String> lista = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["condev"].ConnectionString))
            {

                lista = await connection.QueryAsync<String>("[dbo].[usp_Sede_Obtener]", commandType: CommandType.StoredProcedure).ConfigureAwait(true);
                connection.Close();
            }
            return lista;
        }

        public async Task<IEnumerable<String>> EspecialidadObtener()
        {
            IEnumerable<String> lista = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["condev"].ConnectionString))
            {
                lista = await connection.QueryAsync<String>("[dbo].[usp_Especialidad_Obtener]", commandType: CommandType.StoredProcedure).ConfigureAwait(true);
                connection.Close();
            }
            return lista;
        }


    }
}
