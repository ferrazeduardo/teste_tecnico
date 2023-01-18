using API_ControleQualidade.Models.DTOs;
using API_ControleQualidade.Models.Entidades;
using API_ControleQualidade.Models.Interfaces.Business;
using API_ControleQualidade.Models.Interfaces.Repository;
using API_ControleQualidade.Repository;
using AutoMapper;
using System.Linq;

namespace API_ControleQualidade.Business
{
    public class LoteBusiness : ILoteBusiness
    {
        private readonly ILoteRepository _loteRepository;
        private readonly IMapper _mapper;
        private readonly IEnsaioQualidadeRepository _ensaioQualidadeRepository;
        private readonly IMetodologiaAvaliacaoRepository _metodologiaAvaliacaoRepository;
        private readonly IParametroRepository _parametroRepository;

        public LoteBusiness(ILoteRepository loteRepository,
            IMapper mapper,
            IMetodologiaAvaliacaoRepository metodologiaAvaliacaoRepository,
            IParametroRepository parametroRepository,
            IEnsaioQualidadeRepository ensaioQualidadeRepository)
        {
            _loteRepository = loteRepository;
            _mapper = mapper;
            _ensaioQualidadeRepository = ensaioQualidadeRepository;
            _metodologiaAvaliacaoRepository = metodologiaAvaliacaoRepository;
            _parametroRepository = parametroRepository;
        }

        public IEnumerable<LoteDTO> GetAll()
        {
            IEnumerable<Lote> lotes = _loteRepository.AllGet();
            IEnumerable<LoteDTO> loteDTOs = _mapper.Map<List<LoteDTO>>(lotes);

            return loteDTOs;
        }

        public LoteDTO GetLote(int id)
        {
            LoteDTO loteDTO = GetLoteDTO(id);

            loteDTO.MetodologiaAvalicaoDTO = GetMetodologiaAvalicaoDTO(id);

            loteDTO.ParametroDTOs = GetParametroDTOs(id);

            if (loteDTO.STATUS.Equals("PENDENTE"))
                return loteDTO;

            IEnumerable<EnsaioQualidade> ensaiosQualidade = _ensaioQualidadeRepository.GetEnsaioQualidadeByIdLote(id);
            bool valorQuantitativoFalso = ensaiosQualidade.Any(ensaio => ensaio.VL_QUALITATIVO == "false");

            if (valorQuantitativoFalso is true)
            {
                loteDTO.STATUS = "Fora de Faixa";
                return loteDTO;
            }

            loteDTO.STATUS = RetornarLoteStatusDaMedia(loteDTO, ensaiosQualidade);

            return loteDTO;


        }

        private string RetornarLoteStatusDaMedia(LoteDTO loteDTO,IEnumerable<EnsaioQualidade> ensaiosQualidades)
        {
            string status = string.Empty;

            foreach (var resultadoDentroDaFaixa in from ParametroDTO parametro in loteDTO.ParametroDTOs
                                      let resultado = RegraLimiteInferiorESuperior(loteDTO.MetodologiaAvalicaoDTO, parametro, ensaiosQualidades)
                                      select resultado)
            {
                if (resultadoDentroDaFaixa)
                {
                    status = "Dentro da faixa";
                }
                else
                {
                    status = "Fora de Faixa";
                    break;
                }
            }

            return status;
        }

        private IEnumerable<ParametroDTO> GetParametroDTOs(int id)
        {
            var Parametros = _parametroRepository.GetParametroByIdLote(id);
            return _mapper.Map<IEnumerable<ParametroDTO>>(Parametros);
        }

        private LoteDTO GetLoteDTO(int id)
        {
            Lote lote = _loteRepository.GetLote(id);
            LoteDTO loteDTO = _mapper.Map<LoteDTO>(lote);
            return loteDTO;
        }

        private MetodologiaAvalicaoDTO GetMetodologiaAvalicaoDTO(int id_lote)
        {
            MetodolodiaAvalicao metodolodiaAvalicao = _metodologiaAvaliacaoRepository.GetMetodologiaAvaliacaoByIdLotacao(id_lote);
            MetodologiaAvalicaoDTO metodolodiaAvalicaoDTO = _mapper.Map<MetodologiaAvalicaoDTO>(metodolodiaAvalicao);

            return metodolodiaAvalicaoDTO;
        }

        private static bool RegraLimiteInferiorESuperior(MetodologiaAvalicaoDTO metodolodiaAvalicao,
            ParametroDTO parametro,
            IEnumerable<EnsaioQualidade> ensaio)
        {
            IEnumerable<EnsaioQualidade> ensaioFiltradoPeloParametro = ensaio.Where(ensaio => ensaio.ID_PARAMETRO == parametro.ID);
            bool regraLimiteInferior, regraLimiteSuperior;

            var somaTotal = ensaioFiltradoPeloParametro.Sum(ensaio => ensaio.VL_QUANTITATIVO);

            var media = somaTotal / metodolodiaAvalicao.QT_CALCULO;

            regraLimiteInferior = parametro.LIMITE_INFERIOR == 0 ? true : media > parametro.LIMITE_INFERIOR;
            regraLimiteSuperior = parametro.LIMITE_SUPERIOR == 0 ? true : media < parametro.LIMITE_SUPERIOR;

            return regraLimiteInferior && regraLimiteSuperior;
        }
    }
}
