using API_ControleQualidade.Models.DTOs;
using API_ControleQualidade.Models.Entidades;

namespace API_ControleQualidade.Models.Interfaces.Repository
{
    public interface IEnsaioQualidadeRepository
    {
        IEnumerable<EnsaioQualidade> GetEnsaioQualidadeByIdLote(int id_lote);
        int GetMaxEnsioQualidadeNrOrdemByIdLote(int id_lote);
        void InsertEnsaioQualidade(EnsaioQualidadeDTO ensaioQualidade);
    }
}
