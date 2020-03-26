using AutoMapper;
using CVControl.Data.Entidades;
using CVControl.Model;

namespace CVControl.Application.Mappers
{
    public class IntervaloFilhosProfile : Profile
    {
        public IntervaloFilhosProfile()
        {
            CreateMap<IntervaloFilhos, IntervaloFilhosDTO>()
                .ForMember(dest => dest.IdIntervaloFilhos, opt => opt.MapFrom(src => src.IdIntervaloFilhos))
                .ForMember(dest => dest.Intervalo, opt => opt.MapFrom(src => src.Intervalo));
        }
    }
}