using Vendas.Infrastructure.Data;
using Vendas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Infrastructure.Repositories
{
    public class ClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> ObterTodosClientes()
        {
            return await _context.Clientes
            .OrderBy(c => c.Id).ToListAsync();
        }
       
        public async Task<Cliente?> ObterClientePorId(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> CadastrarCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<List<Cliente>> ObterClientesAtivos()
        {
            return await _context.Clientes
                .Where(c => c.Ativo == true)
                .OrderBy(c => c.Id)
                .ToListAsync();
        }

    }
}
