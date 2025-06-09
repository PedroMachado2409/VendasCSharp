using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Vendas.Domain.Entities
{
    public class Produto
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Unidade { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public double Preco { get; set; }
        public DateTime DtCadastro { get; set; } = DateTime.UtcNow;     
        public Guid Codigo { get; set; } = Guid.NewGuid();
        protected Produto() { }
        public Produto(string nome, string unidade, string observacao, double preco)
        {
            Nome = nome;
            Unidade = unidade;
            Observacao = observacao;
            Preco = preco;
        }
        public void Atualizar(string nome, string unidade, string observacao, double preco)
        {
            Nome = nome;
            Unidade = unidade;
            Observacao = observacao;
            Preco = preco;
        }

    }
}
