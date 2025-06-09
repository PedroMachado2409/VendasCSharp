using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Data;

namespace Vendas.Infrastructure.Repositories
{
    public class MovimentacaoEstoqueRepository
    {
        private readonly AppDbContext _context;
        public MovimentacaoEstoqueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MovimentacaoEstoque>> ObterTodasMovimentacoes()
        {
            return await _context.MovimentacoesEstoque
                .OrderBy(m => m.Id)
                .ToListAsync();
        }

        public async Task<MovimentacaoEstoque?> ObterMovimentacaoPorId(int id)
        {
            return await _context.MovimentacoesEstoque.FindAsync(id);
        }

        public async Task<MovimentacaoEstoque> CadastrarMovimentacao(MovimentacaoEstoque movimentacao)
        {
            await _context.MovimentacoesEstoque.AddAsync(movimentacao);
            await _context.SaveChangesAsync();
            return movimentacao;
        }


    }
}
