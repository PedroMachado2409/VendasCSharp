using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Enum;

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
        public DbSet<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder
                .Entity<MovimentacaoEstoque>()
                .Property(e => e.Tipo)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
