using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso.Entidad;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Data;

namespace Acceso.Datos
{
    public class LogDA
    {
        public async Task<IEnumerable<Usuario>> ListaLog(int id)
        {
            IEnumerable<Usuario> lista = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["condev"].ConnectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@idlog", id);

                lista = await connection.QueryAsync<Usuario>("[dbo].[usp_Log_Obtener]",parametros, commandType: CommandType.StoredProcedure).ConfigureAwait(true);
                connection.Close();
            }
            return lista;
        }

        public async Task<int> RegistrarLog(Usuario input)
        {
            int retorno = 0;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["condev"].ConnectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@idusuario", input.idusuario);
                parametros.Add("@uscre", input.uscre);

                parametros.Add("@id", null, DbType.Int32, ParameterDirection.Output);

                using (var dr = await connection.ExecuteReaderAsync("[dbo].[usp_Log_Registrar]", parametros, commandType: CommandType.StoredProcedure))
                {
                    retorno = parametros.Get<int>("@id");
                }
                connection.Close();
            }
            return retorno;
        }

        public async Task<IEnumerable<Usuario>> ListaLogFiltro(string sede,string especialidad)
        {
            IEnumerable<Usuario> lista = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["condev"].ConnectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@sede", sede);
                parametros.Add("@especialidad", especialidad);

                lista = await connection.QueryAsync<Usuario>("[dbo].[usp_LogFiltro_Obtener]", parametros, commandType: CommandType.StoredProcedure).ConfigureAwait(true);
                connection.Close();
            }
            return lista;
        }
    }
}
