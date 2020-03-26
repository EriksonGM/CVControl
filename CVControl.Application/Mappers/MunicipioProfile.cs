using AutoMapper;
using CVControl.Data.Entidades;
using CVControl.Model;

namespace CVControl.Application.Mappers
{
    public class MunicipioProfile : Profile
    {
        public MunicipioProfile()
        {
            CreateMap<Municipio, MunicipioDTO>()
                .ForMember(dest => dest.IdMunicipio, opt => opt.MapFrom(src => src.IdMunicipio))
                .ForMember(dest => dest.IdProvincia, opt => opt.MapFrom(src => src.IdProvincia))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));
        }
    }
}