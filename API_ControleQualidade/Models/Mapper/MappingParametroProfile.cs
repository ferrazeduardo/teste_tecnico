using API_ControleQualidade.Models.DTOs;
using API_ControleQualidade.Models.Entidades;
using AutoMapper;

namespace API_ControleQualidade.Models.Mapper
{
    public class MappingParametroProfile : Profile
    {
        public MappingParametroProfile()
        {
            CreateMap<Parametro, ParametroDTO>()
               .ForMember(dest => dest.ID,
                           map => map.MapFrom(src => src.ID_PARAMETRO))
               .ForMember(dest => dest.DESCRICAO,
                           map => map.MapFrom(src => src.DS_PARAMETRO))
               .ForMember(dest => dest.VALOR_NOMINAL,
                           map => map.MapFrom(src => src.VALOR_NOMINAL))
               .ForMember(dest => dest.LIMITE_INFERIOR,
                           map => map.MapFrom(src => src.LIMITE_INFERIOR))
               .ForMember(dest => dest.LIMITE_SUPERIOR,
                           map => map.MapFrom(src => src.LIMITE_SUPERIOR))
               .ForMember(dest => dest.TIPO,
                           map => map.MapFrom(src => src.TipoParametro != null ? src.TipoParametro.DS_TIPO_PARAMETRO : null));
        }
    }
}
