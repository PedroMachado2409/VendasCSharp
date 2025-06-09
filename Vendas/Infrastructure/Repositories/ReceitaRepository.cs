using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Data;

namespace Vendas.Infrastructure.Repositories
{
    public class ReceitaRepository
    {
        private readonly AppDbContext _context;

        public ReceitaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Receita>> ObterTodasAsReceitas()
        {
            return await _context.Receitas
                .Include(r => r.Cliente)
                .OrderBy(r => r.Id)
                .ToListAsync();
        }

        public async Task<Receita?> ObterReceitaPorId(int id)
        {
            return await _context.Receitas
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Receita> CadastrarReceita(Receita receita)
        {
            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();
            return receita;
        }

        public async Task<Receita> BaixarReceita(Receita receita)
        {
            _context.Receitas.Update(receita);
            await _context.SaveChangesAsync();
            return receita;
        }
    }
}
