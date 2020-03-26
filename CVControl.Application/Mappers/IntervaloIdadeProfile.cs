using AutoMapper;
using CVControl.Data.Entidades;
using CVControl.Model;

namespace CVControl.Application.Mappers
{
    public class IntervaloIdadeProfile : Profile
    {
        public IntervaloIdadeProfile()
        {
            CreateMap<IntervaloIdade, IntervaloIdadeDTO>()
                .ForMember(dest => dest.IdIntervaloIdade, opt => opt.MapFrom(src => src.IdIntervaloIdade))
                .ForMember(dest => dest.Intervalo, opt => opt.MapFrom(src => src.Intervalo));
        }
    }
}