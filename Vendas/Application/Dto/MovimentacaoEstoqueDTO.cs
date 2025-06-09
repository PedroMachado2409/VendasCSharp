using System.ComponentModel.DataAnnotations;
using Vendas.Domain.Entities;
using Vendas.Domain.Enum;

namespace Vendas.Application.Dto
{
    public class MovimentacaoEstoqueDTO
    {

        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
        public MovimentacaoTipo Tipo { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; } = string.Empty;
        public long ProdutoId { get; set; }
    }
}
