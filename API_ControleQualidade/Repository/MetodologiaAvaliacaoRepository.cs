using API_ControleQualidade.Models.Entidades;
using API_ControleQualidade.Models.Interfaces.Repository;
using Dapper;
using System.Data.SqlClient;

namespace API_ControleQualidade.Repository
{
    public class MetodologiaAvaliacaoRepository : IMetodologiaAvaliacaoRepository
    {
        private readonly IConnectionString _connectionString;
        private SqlConnection? _con;

        public MetodologiaAvaliacaoRepository(IConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public MetodolodiaAvalicao GetMetodologiaAvaliacaoByIdLotacao(int id_lote)
        {
            const String sql = @"
                 SELECT
                 *
                 FROM ES_METODOLOGIA_AVALIACAO 
                 WHERE ID_LOTE = @ID_LOTE
            ";

            var parametro = new
            {
                ID_LOTE = id_lote
            };

            try
            {
                using (_con = new SqlConnection(_connectionString.GetConnectionString()))
                {
                    _con.Open();

                    MetodolodiaAvalicao metodolodiaAvalicao = _con.Query<MetodolodiaAvalicao>(sql, parametro).FirstOrDefault();

                    return metodolodiaAvalicao;
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
