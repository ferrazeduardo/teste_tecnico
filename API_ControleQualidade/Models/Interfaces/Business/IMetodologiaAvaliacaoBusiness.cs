using API_ControleQualidade.Models.DTOs;
using API_ControleQualidade.Models.Entidades;

namespace API_ControleQualidade.Models.Interfaces.Business
{
    public interface IMetodologiaAvaliacaoBusiness
    {
        MetodologiaAvalicaoDTO GetMetodologiasAvaliacaoByIdLote(int id);
    }
}
