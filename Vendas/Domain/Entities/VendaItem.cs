using System.ComponentModel.DataAnnotations;

namespace Vendas.Domain.Entities
{
    public class VendaItem
    {
        [Key]
        public int Id { get; set; }
        public int VendaId { get; set; }
        public Venda Venda { get; set; } 
        public long ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }

    }
}
