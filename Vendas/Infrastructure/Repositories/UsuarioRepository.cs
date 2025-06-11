using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Data;

namespace Vendas.Infrastructure.Repositories
{
    public class UsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObterUsuarioPorEmail(string email)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<Usuario>> ObterTodosUsuarios()
        {
            return await _context.Usuarios.OrderBy(u => u.Id).ToListAsync();    
                
        }

        public async Task<Usuario?> ObterUsuarioPorId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> CadastrarUsuario(Usuario novoUsuario)
        {
            await _context.Usuarios.AddAsync(novoUsuario);
            await _context.SaveChangesAsync();
            return novoUsuario;
        }

        
    }
}
