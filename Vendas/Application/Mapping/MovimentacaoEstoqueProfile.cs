using AutoMapper;
using Vendas.Application.Dto;
using Vendas.Domain.Entities;

namespace Vendas.Application.Mapping
{
    public class MovimentacaoEstoqueProfile : Profile
    {
        public MovimentacaoEstoqueProfile()
        {
            CreateMap<MovimentacaoEstoque, MovimentacaoEstoqueDTO>()
                .ReverseMap();
        }
    }
}
