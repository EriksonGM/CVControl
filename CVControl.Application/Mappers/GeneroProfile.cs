using AutoMapper;
using CVControl.Data.Entidades;
using CVControl.Model;

namespace CVControl.Application.Mappers
{
    public class GeneroProfile : Profile
    {
        public GeneroProfile()
        {
            CreateMap<Genero, GeneroDTO>()
                .ForMember(dest => dest.IdGenero, opt => opt.MapFrom(src => src.IdGenero))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));
        }
    }
}