using AutoMapper;
using Vendas.Application.Dto;
using Vendas.Domain.Entities;

namespace Vendas.Application.Mapping
{
    public class VendaProfile : Profile
    {
        public VendaProfile()
        {
            CreateMap<Venda, VendaResponseDTO>()
                .ForMember(dest => dest.ClienteNome, opt => opt.MapFrom(src => src.Cliente.Nome));
           

            CreateMap<VendaItem, VendaItemResponseDTO>()
                .ForMember(dest => dest.ProdutoNome, opt => opt.MapFrom(src => src.Produto.Nome));

            CreateMap<VendaRequestDTO, Venda>()
                .ForMember(dest => dest.Itens, opt => opt.Ignore())
                .ForMember(dest => dest.ValorTotal, opt => opt.Ignore())
                .ForMember(dest => dest.DataVenda, opt => opt.Ignore());

            CreateMap<VendaItemRequestDTO, VendaItem>()
                .ForMember(dest => dest.Produto, opt => opt.Ignore())
                .ForMember(dest => dest.VendaId, opt => opt.Ignore())
                .ForMember(dest => dest.Venda, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
