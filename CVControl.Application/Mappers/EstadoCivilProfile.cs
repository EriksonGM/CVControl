using AutoMapper;
using CVControl.Data.Entidades;
using CVControl.Model;

namespace CVControl.Application.Mappers
{
    public class EstadoCivilProfile : Profile
    {
        public EstadoCivilProfile()
        {
            CreateMap<EstadoCivil, EstadoCivilDTO>()
                .ForMember(dest => dest.IdEstadoCivil, opt => opt.MapFrom(src => src.IdEstadoCivil))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado));
        }
    }
}