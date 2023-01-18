using API_ControleQualidade.Models.Entidades;
using API_ControleQualidade.Models.Interfaces.Repository;
using Dapper;
using System.Data.SqlClient;

namespace API_ControleQualidade.Repository
{
    public class LoteRepository : ILoteRepository
    {
        private readonly IConnectionString _connectionString;
        private SqlConnection? _con;
        public LoteRepository(IConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Lote> AllGet()
        {
            const String sql = @"
                  SELECT
                    *
                  FROM ES_LOTE
            ";

            try
            {
                using (_con = new SqlConnection(_connectionString.GetConnectionString()))
                {
                    _con.Open();

                    IEnumerable<Lote> lotes = _con.Query<Lote>(sql);
                    return lotes;
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

        public Lote GetLote(int id)
        {
            const String sql = @"
                  SELECT
                    ID_LOTE,
                    NM_LOTE,
                    CASE
                        WHEN (SELECT ISNULL(MAX(NR_ORDEM),0)
                              FROM ES_ENSAIO_QUALIDADE
                              WHERE ID_LOTE = @ID_LOTE) < 3
                        THEN 'PENDENTE'
                        ELSE 'NÃO PENDENTE'
                  END STATUS
                  FROM ES_LOTE
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

                    Lote lote = _con.Query<Lote>(sql, parametro).FirstOrDefault();
                    return lote;
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
