using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Vendas.Application.Dto;
using Vendas.Domain.Entities;

namespace Vendas.Application.Mapping
{
    public class SaldoProfile : Profile
    {
         public SaldoProfile()
        {
            CreateMap<SaldoDTO, MovimentacaoEstoque>().ReverseMap();
               
        }
    }
}
