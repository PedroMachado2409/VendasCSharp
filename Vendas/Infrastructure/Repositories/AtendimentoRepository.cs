using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Data;

namespace Vendas.Infrastructure.Repositories
{
    public class AtendimentoRepository
    {
        private readonly AppDbContext _context;

        public AtendimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Atendimento>> ObterTodosOsAtendimentos()
        {
            return await _context.Atendimentos
                .Include(a => a.Cliente)
                .Include(a => a.Pareceres)
                 .ThenInclude(p => p.Usuario)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<Atendimento> CriarAtendimento(Atendimento atendimento)
        {
            await _context.Atendimentos.AddAsync(atendimento);
            await _context.SaveChangesAsync();
            return atendimento;
        }

        public async Task<Atendimento?> ObterAtendimentoPorId(int id)
        {
            return await _context.Atendimentos
                .Include(a => a.Cliente)
                .Include(a => a.Pareceres)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Atendimento> AtualizarAtendimento(Atendimento atendimento)
        {
            _context.Atendimentos.Update(atendimento);
            await _context.SaveChangesAsync();
            return atendimento;
        }

    }

}
