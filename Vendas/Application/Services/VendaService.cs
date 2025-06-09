using AutoMapper;
using Vendas.Application.Dto;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Data;
using Vendas.Infrastructure.Repositories;

namespace Vendas.Application.Services
{
    public class VendaService
    {
        private readonly AppDbContext _context;
        private readonly ClienteRepository _clienteRepository;
        private readonly ProdutoRepository _produtoRepository;
        private readonly VendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public VendaService(AppDbContext context, IMapper mapper, ClienteRepository clienteRepository, ProdutoRepository produtoRepository, VendaRepository vendaRepository)
        {
            _context = context;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _vendaRepository = vendaRepository;
        }

        public async Task<Venda> CriarVendaAsync(VendaRequestDTO dto)
        {
          
            var cliente = await _clienteRepository.ObterClientePorId(dto.ClienteId)
            ?? throw new Exception("Cliente não encontrado.");

            var venda = new Venda
            {
                ClienteId = dto.ClienteId,
                Cliente = cliente,
                DataVenda = DateTime.UtcNow,
                Itens = new List<VendaItem>()
            };

            await AdicionarItemsDaVenda(venda, dto.Itens);

            var vendaCriada = await _vendaRepository.CriarVenda(venda);
            await GerarReceita(vendaCriada);

            return _mapper.Map<Venda>(vendaCriada);

        }

        public async Task<List<VendaResponseDTO>> ObterVendasAsync()
        {
            var vendas = await _vendaRepository.ObterVendas()
            ?? throw new Exception("Nenhuma venda encontrada.");

          
            return _mapper.Map<List<VendaResponseDTO>>(vendas);
        }


        //----------------------------------------------- METODOS PRIVADOS -----------------------------------------------

        private async Task AdicionarItemsDaVenda(Venda venda, List<VendaItemRequestDTO> itensDto)
        {
            foreach (var itemDto in itensDto)
            {
                var produto = await _produtoRepository.ObterProdutoPorId(itemDto.ProdutoId);
                if (produto == null)
                {
                    throw new Exception($"Produto com ID {itemDto.ProdutoId} não encontrado.");
                }

                venda.Itens.Add(new VendaItem
                {
                    ProdutoId = itemDto.ProdutoId,
                    Quantidade = itemDto.Quantidade,
                    PrecoUnitario = itemDto.PrecoUnitario
                });
            }

            venda.ValorTotal = venda.Itens.Sum(i => i.PrecoUnitario * i.Quantidade);
        }

        private async Task GerarReceita(Venda venda)
        {
           Receita receita = new Receita
            {
                Cliente = venda.Cliente,
                DtCadastro = DateTime.UtcNow,
                ValorTotal = venda.ValorTotal,
                CodigoOrigem = venda.CodigoVenda,
                Descricao = $"Venda realizada em {venda.DataVenda:dd/MM/yyyy} - Código: {venda.id}",
           };
            await _context.Receitas.AddAsync(receita);
            await _context.SaveChangesAsync();
        }

    }
}
