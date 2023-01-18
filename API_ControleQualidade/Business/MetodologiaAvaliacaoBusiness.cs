using API_ControleQualidade.Models.DTOs;
using API_ControleQualidade.Models.Entidades;
using API_ControleQualidade.Models.Interfaces.Business;
using API_ControleQualidade.Models.Interfaces.Repository;
using API_ControleQualidade.Repository;
using AutoMapper;

namespace API_ControleQualidade.Business
{
    public class MetodologiaAvaliacaoBusiness : IMetodologiaAvaliacaoBusiness
    {
        private readonly IMetodologiaAvaliacaoRepository _metodologiaAvaliacaoRepository;
        private readonly IMapper _mapper;
        private readonly IParametroRepository _parametroRepository;

        public MetodologiaAvaliacaoBusiness(IMetodologiaAvaliacaoRepository metodologiaAvaliacaoRepository, IMapper mapper, IParametroRepository parametroRepository)
        {
            _metodologiaAvaliacaoRepository = metodologiaAvaliacaoRepository;
            _mapper = mapper;
            _parametroRepository = parametroRepository;
        }

        public MetodologiaAvalicaoDTO GetMetodologiasAvaliacaoByIdLote(int id)
        {
            MetodolodiaAvalicao metodolodiaAvalicao = _metodologiaAvaliacaoRepository.GetMetodologiaAvaliacaoByIdLotacao(id);
            MetodologiaAvalicaoDTO metodolodiaAvalicaoDTO = _mapper.Map<MetodologiaAvalicaoDTO>(metodolodiaAvalicao);


            return metodolodiaAvalicaoDTO;
        }
    }
}
