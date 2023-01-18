using API_ControleQualidade.Models.DTOs;
using API_ControleQualidade.Models.Entidades;
using AutoMapper;

namespace API_ControleQualidade.Models.Mapper
{
    public class MappingLoteProfile : Profile
    {
        public MappingLoteProfile()
        {
            CreateMap<Lote, LoteDTO>()
                .ForMember(dest => dest.Id,
                            map => map.MapFrom(src => src.ID_LOTE))
                .ForMember(dest => dest.DESCRICAO,
                            map => map.MapFrom(src => src.NM_LOTE))
                .ForMember(dest => dest.STATUS,
                            map => map.MapFrom(src => src.STATUS));
        }
    }
}
