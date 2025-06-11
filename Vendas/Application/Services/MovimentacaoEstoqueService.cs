using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vendas.Application.Dto;
using Vendas.Domain.Entities;
using Vendas.Domain.Enum;
using Vendas.Infrastructure.Data;

namespace Vendas.Application.Services
{
    public class MovimentacaoEstoqueService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MovimentacaoEstoqueService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MovimentacaoEstoqueDTO>> ObterTodasMovimentacoesEstoque()
        {
            var Movimetacoes = await _context.MovimentacoesEstoque.ToListAsync();
            return _mapper.Map<List<MovimentacaoEstoqueDTO>>(Movimetacoes);
        }

        public async Task<MovimentacaoEstoqueDTO?> ObterMovimentacaoEstoquePorId(int id)
        {
            var movimentacao = await _context.MovimentacoesEstoque.FindAsync(id);
            return _mapper.Map<MovimentacaoEstoqueDTO?>(movimentacao);
        }

        public async Task<MovimentacaoEstoqueDTO> CadastrarMovimentacaoEstoque(MovimentacaoEstoqueDTO movimentacaoDto)
        {
            

            if(movimentacaoDto.Tipo == MovimentacaoTipo.Saida)
            {
                movimentacaoDto.Quantidade = movimentacaoDto.Quantidade * -1;
            }

            var movimentacao = _mapper.Map<MovimentacaoEstoque>(movimentacaoDto);

            await _context.MovimentacoesEstoque.AddAsync(movimentacao);
            await _context.SaveChangesAsync();
            return _mapper.Map<MovimentacaoEstoqueDTO>(movimentacao);
        }

        public async Task<SaldoDTO> ObterSaldoEstoquePorProdutoId(long produtoId)
        {
            var movimentacoes = await _context.MovimentacoesEstoque
                .Where(m => m.ProdutoId == produtoId)
                .Include(m => m.Produto)
                .ToListAsync();

            var saldo = movimentacoes.Sum(m =>
                m.Tipo == MovimentacaoTipo.Entrada
                ? Math.Abs(m.Quantidade)
                : -Math.Abs(m.Quantidade));

            return new SaldoDTO
            {
                ProdutoId = (int)produtoId,
                ProdutoNome = movimentacoes.FirstOrDefault()?.Produto?.Nome ?? string.Empty,
                Saldo = saldo
            };
        }

    }
}
