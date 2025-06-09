using System.ComponentModel.DataAnnotations;

namespace Vendas.Domain.Entities
{
    public class Venda
    {
        [Key]
        public int id { get; set; }
        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } 
        public DateTime DataVenda { get; set; } = DateTime.UtcNow;
        public List<VendaItem> Itens { get; set; } = new List<VendaItem>();
        public Guid CodigoVenda { get; set; } = Guid.NewGuid();
        public double ValorTotal { get; set; } = 0.0;

    }
}
