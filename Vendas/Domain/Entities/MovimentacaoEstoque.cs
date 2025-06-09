using System.ComponentModel.DataAnnotations;
using Vendas.Domain.Enum;

namespace Vendas.Domain.Entities
{
    public class MovimentacaoEstoque
    {

        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
        public MovimentacaoTipo Tipo { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; } = string.Empty;
        public long ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public Guid CodigoOrigem { get; set; } = Guid.NewGuid();

    }
}
