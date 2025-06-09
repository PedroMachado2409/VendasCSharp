using System.ComponentModel.DataAnnotations;

namespace Vendas.Application.Dto
{
    public class ProdutoDTO
    {
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Unidade { get; set; } = string.Empty;
        [Required]
        public string Observacao { get; set; } = string.Empty;
        [Required]
        public double Preco { get; set; }

        public DateTime DtCadastro { get; set; } = DateTime.UtcNow;
        public Guid Codigo { get; set; } = Guid.NewGuid();
    }
}
