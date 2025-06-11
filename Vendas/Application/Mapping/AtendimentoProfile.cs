using AutoMapper;
using Vendas.Application.Dto;
using Vendas.Domain.Entities;

namespace Vendas.Application.Mapping
{
    public class AtendimentoProfile : Profile
    {
        public AtendimentoProfile()
        {
            CreateMap<AtendimentoDTO, Atendimento > ()
                .ForMember(dest => dest.Pareceres, opt => opt.MapFrom(src => src.Pareceres))
                .ReverseMap();
            CreateMap<ParecerDTO, Parecer>()
                .ReverseMap();
        }
    }
}
