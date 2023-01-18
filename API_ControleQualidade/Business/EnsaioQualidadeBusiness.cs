using API_ControleQualidade.Models.DTOs;
using API_ControleQualidade.Models.Entidades;
using API_ControleQualidade.Models.Interfaces.Business;
using API_ControleQualidade.Models.Interfaces.Repository;
using API_ControleQualidade.Repository;
using AutoMapper;

namespace API_ControleQualidade.Business
{
    public class EnsaioQualidadeBusiness : IEnsaioQualidadeBusiness
    {
        private readonly IMapper _mapper;
        private readonly IEnsaioQualidadeRepository _ensaioQualidadeRepository;

        public EnsaioQualidadeBusiness(IMapper mapper,IEnsaioQualidadeRepository ensaioQualidadeRepository)
        {
            _mapper = mapper;
            _ensaioQualidadeRepository = ensaioQualidadeRepository;
        }

        public void InsertEnsarioQualidade(IEnumerable<EnsaioQualidadeDTO> ensaioQualidadeDTOs)
        {
            int nr_ordem = GetMaxNrOrdem(ensaioQualidadeDTOs);

            foreach (var ensaioQualidadeDTO in ensaioQualidadeDTOs)
            {
                ensaioQualidadeDTO.NR_ORDEM = nr_ordem + 1;
                _ensaioQualidadeRepository.InsertEnsaioQualidade(ensaioQualidadeDTO);
            }

        }

        private int GetMaxNrOrdem(IEnumerable<EnsaioQualidadeDTO> ensaioQualidadeDTOs)
        {
            EnsaioQualidadeDTO ensaioQualidadeDTO = ensaioQualidadeDTOs.First();
            int nr_ordem = _ensaioQualidadeRepository.GetMaxEnsioQualidadeNrOrdemByIdLote(ensaioQualidadeDTO.lote);
            return nr_ordem;
        }
    }
}
