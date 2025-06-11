using AutoMapper;
using Vendas.Application.Dto;
using Vendas.Domain.Entities;

namespace Vendas.Application.Mapping
{
    public class ReceitaProfile : Profile
    {
        public ReceitaProfile()
        {
            CreateMap<Receita, ReceitaDTO>()
                .ReverseMap();

        }
    }
    
}
