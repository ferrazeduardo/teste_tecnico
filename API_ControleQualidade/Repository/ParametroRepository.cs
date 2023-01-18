using API_ControleQualidade.Models.Entidades;
using API_ControleQualidade.Models.Interfaces.Repository;
using Dapper;
using System.Data.SqlClient;

namespace API_ControleQualidade.Repository
{
    public class ParametroRepository : IParametroRepository
    {
        private readonly IConnectionString _connectionString;
        private SqlConnection? _con;

        public ParametroRepository(IConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Parametro> GetParametroByIdLote(int id)
        {
            const String sql = @"
                  SELECT
                     P.ID_PARAMETRO
                     ,P.DS_PARAMETRO
                     ,P.VALOR_NOMINAL
                     ,P.LIMITE_INFERIOR
                     ,P.LIMITE_SUPERIOR
                     ,P.ID_LOTE
                     ,TP.ID_TIPO_PARAMETRO
                     ,TP.DS_TIPO_PARAMETRO
                  FROM  ES_PARAMETRO P
                  	INNER JOIN ES_TIPO_PARAMETRO TP
                  ON TP.ID_TIPO_PARAMETRO = P.ID_TIPO_PARAMETRO
                  WHERE ID_LOTE = @ID_LOTE
            ";

            var parametro = new
            {
                ID_LOTE = id
            };

            try
            {
                using (_con = new SqlConnection(_connectionString.GetConnectionString()))
                {
                    _con.Open();

                    IEnumerable<Parametro> parametros = _con.Query<Parametro,TipoParametro, Parametro> (sql,param: parametro,
                        map:(p,tp) =>
                        {
                            p.TipoParametro = tp;
                            return p;
                        },splitOn: "ID_PARAMETRO,ID_TIPO_PARAMETRO");
                    return parametros;
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
