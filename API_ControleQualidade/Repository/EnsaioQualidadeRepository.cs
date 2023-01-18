using API_ControleQualidade.Models.DTOs;
using API_ControleQualidade.Models.Entidades;
using API_ControleQualidade.Models.Interfaces.Repository;
using Dapper;
using System.Data.SqlClient;

namespace API_ControleQualidade.Repository
{
    public class EnsaioQualidadeRepository : IEnsaioQualidadeRepository
    {
        private readonly IConnectionString _connectionString;
        private SqlConnection? _con;

        public EnsaioQualidadeRepository(IConnectionString connectionString)
        {
            _connectionString = connectionString;
        }


        public IEnumerable<EnsaioQualidade> GetEnsaioQualidadeByIdLote(int id_lote)
        {
            const String sql = @"
                  SELECT
                    ID_ENSAIO_QUALIDADE,
                    ID_PARAMETRO,
                    VL_QUANTITATIVO,
                    VL_QUALITATIVO,
                    ID_LOTE,
                    NR_ORDEM
                  FROM ES_ENSAIO_QUALIDADE
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

                    IEnumerable<EnsaioQualidade> ensaioQualidades = _con.Query<EnsaioQualidade>(sql, parametro);

                    return ensaioQualidades;
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

        public int GetMaxEnsioQualidadeNrOrdemByIdLote(int id_lote)
        {
            const String sql = @"
                  SELECT
                  ISNULL(MAX(NR_ORDEM),0)
                  FROM ES_ENSAIO_QUALIDADE 
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

                    int nr_ordem = _con.Query<int>(sql, parametro).FirstOrDefault();

                    return nr_ordem;
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

        public void InsertEnsaioQualidade(EnsaioQualidadeDTO ensaioQualidade)
        {
            const String sql = @"
                 INSERT INTO ES_ENSAIO_QUALIDADE
                (
                	ID_LOTE,
                	ID_PARAMETRO,
                	NR_ORDEM,
                	DH_REGISTRO,
                	VL_QUANTITATIVO,
                	VL_QUALITATIVO
                ) VALUES (
                	@ID_LOTE,
                	@ID_PARAMETRO,
                	@NR_ORDEM,
                	@DH_REGISTRO,
                	@VL_QUANTITATIVO,
                	@VL_QUALITATIVO
                )
            ";

            var numero = ensaioQualidade.vl_quantitativo.ToString();

            var parametro = new
            {
                ID_LOTE = ensaioQualidade.lote,
                ID_PARAMETRO = ensaioQualidade.parametro,
                DH_REGISTRO = DateTime.Now,
                VL_QUANTITATIVO = ensaioQualidade.vl_quantitativo > 0 ? numero.Replace(",",".") : null,
                VL_QUALITATIVO = ensaioQualidade.vl_qualitativo != "" ? ensaioQualidade.vl_qualitativo : null,
                NR_ORDEM = ensaioQualidade.NR_ORDEM
            };

            try
            {
                using (_con = new SqlConnection(_connectionString.GetConnectionString()))
                {
                    _con.Open();

                    _con.Execute(sql, parametro);

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
