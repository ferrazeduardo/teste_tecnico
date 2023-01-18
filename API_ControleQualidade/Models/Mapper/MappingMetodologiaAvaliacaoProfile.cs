using API_ControleQualidade.Models.DTOs;
using API_ControleQualidade.Models.Entidades;
using AutoMapper;

namespace API_ControleQualidade.Models.Mapper
{
    public class MappingMetodologiaAvaliacaoProfile : Profile
    {
        public MappingMetodologiaAvaliacaoProfile()
        {
            CreateMap<MetodolodiaAvalicao, MetodologiaAvalicaoDTO>()
              .ForMember(dest => dest.ID,
                          map => map.MapFrom(src => src.ID_METODO_AVALIACAO))
              .ForMember(dest => dest.DESCRICAO,
                          map => map.MapFrom(src => src.DS_METODO_AVALIACAO))
              .ForMember(dest => dest.QT_CALCULO,
                          map => map.MapFrom(src => src.QT_CALCULO));

        }
    }
}
