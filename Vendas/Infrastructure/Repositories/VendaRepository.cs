using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Data;

namespace Vendas.Infrastructure.Repositories
{
    public class VendaRepository
    {
        private readonly AppDbContext _context;

        public VendaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Venda> CriarVenda(Venda venda)
        {
            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<List<Venda>> ObterVendas()
        {
            return await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Itens)
                    .ThenInclude(i => i.Produto)
                    .OrderBy(v => v.id)
                .ToListAsync();
        }

    }
}
