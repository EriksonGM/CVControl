using AutoMapper;
using CVControl.Data.Entidades;
using CVControl.Model;

namespace CVControl.Application.Mappers
{
    public class ProvinciaProfile : Profile
    {
        public ProvinciaProfile()
        {
            CreateMap<Provincia, ProvinciaDTO>()
                .ForMember(dest => dest.IdProvincia, opt => opt.MapFrom(src => src.IdProvincia))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Municipios, opt => opt.MapFrom(src => src.Municipios));
        }
    }
}