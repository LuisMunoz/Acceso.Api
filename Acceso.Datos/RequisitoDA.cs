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
    public class RequisitoDA
    {

        public async Task<IEnumerable<Requisito>> ListaRequisito()
        {
            IEnumerable<Requisito> lista = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["condev"].ConnectionString))
            {
                lista = await connection.QueryAsync<Requisito>("[dbo].[usp_Requisito_Obtener]").ConfigureAwait(true);
                connection.Close();
            }
            return lista;
        }
        
        public async Task<bool> RegistrarRequisito(Requisito input)
        {
            int retorno = 0;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["condev"].ConnectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@descripcion", input.descripcion);
                parametros.Add("@uscre", input.uscre);
                parametros.Add("@feini", input.feini);
                parametros.Add("@fefin", input.fefin);

                parametros.Add("@id", null, DbType.Int32, ParameterDirection.Output);

                using (var dr = await connection.ExecuteReaderAsync("[dbo].[usp_Requisito_Registrar]", parametros, commandType: CommandType.StoredProcedure))
                {
                    retorno = parametros.Get<int>("@id");
                }
                connection.Close();
            }
            return retorno == 0 ? true : false;
        }
        
        public async Task<bool> ActualizarRequisito(Requisito input)
        {
            int retorno = 0;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["condev"].ConnectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@idrequisito", input.idrequisito);
                parametros.Add("@descripcion", input.descripcion);
                parametros.Add("@flactivo", input.flactivo);
                parametros.Add("@uscre", input.uscre);
                parametros.Add("@feini", input.feini);
                parametros.Add("@fefin", input.fefin);

                retorno = await connection.ExecuteAsync("[dbo].[usp_Requisito_Modificar]", parametros, commandType: CommandType.StoredProcedure);
                connection.Close();
            }
            return retorno == 0 ? true : false;
        }


    }
}
