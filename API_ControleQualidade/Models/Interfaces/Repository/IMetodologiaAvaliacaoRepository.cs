using API_ControleQualidade.Models.Entidades;

namespace API_ControleQualidade.Models.Interfaces.Repository
{
    public interface IMetodologiaAvaliacaoRepository
    {
        MetodolodiaAvalicao GetMetodologiaAvaliacaoByIdLotacao(int id_lote);
    }
}
