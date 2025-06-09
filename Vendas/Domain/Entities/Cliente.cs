using System.ComponentModel.DataAnnotations;

namespace Vendas.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public bool Ativo { get; set; } = true;

        protected Cliente() { }
        public Cliente(string nome, string email, string telefone, string endereco, bool ativo)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Ativo = ativo;
        }
        public void Atualizar(string nome, string email, string telefone, string endereco, bool ativo)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Ativo = ativo;
        }
    }
}
