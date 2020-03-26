using AutoMapper;
using CVControl.Data.Entidades;
using CVControl.Model;

namespace CVControl.Application.Mappers
{
    public class SintomaProfile : Profile
    {
        public SintomaProfile()
        {
            CreateMap<Sintoma, SintomaDTO>()
                .ForMember(dest => dest.IdSintomas, opt => opt.MapFrom(src => src.IdSintomas))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));
        }
    }
}