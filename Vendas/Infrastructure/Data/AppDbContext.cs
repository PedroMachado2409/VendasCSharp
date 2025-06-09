using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;

namespace Vendas.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
       public DbSet<Produto> Produtos { get; set; }
       public DbSet<Cliente> Clientes { get; set; }
       public DbSet<Usuario> Usuarios { get; set; } 
       public DbSet<VendaItem> VendaItems { get; set; }
       public DbSet<Venda> Vendas { get; set; }
       public DbSet<Receita> Receitas { get; set; }
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
