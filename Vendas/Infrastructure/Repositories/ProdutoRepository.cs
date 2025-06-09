using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Data;

namespace Vendas.Infrastructure.Repositories
{
    public class ProdutoRepository
    {

        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> ObterTodosOsProdutos()
        {
            return await _context.Produtos
                .OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Produto?> ObterProdutoPorId(long id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto> CadastrarProduto(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

    }
}
