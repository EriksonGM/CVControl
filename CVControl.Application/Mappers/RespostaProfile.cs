using AutoMapper;
using CVControl.Data.Entidades;
using CVControl.Model;

namespace CVControl.Application.Mappers
{
    public class RespostaProfile : Profile
    {
        public RespostaProfile()
        {
            CreateMap<Resposta, RespostaDTO>()
                .ForMember(dest => dest.IdResposta, opt => opt.MapFrom(src => src.IdResposta))
                .ForMember(dest => dest.IdPergunta, opt => opt.MapFrom(src => src.IdPergunta))
                .ForMember(dest => dest.Texto, opt => opt.MapFrom(src => src.Texto));
        }
    }
}