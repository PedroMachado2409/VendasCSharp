using System.ComponentModel.DataAnnotations;

namespace Vendas.Domain.Entities
{
    public class Despesa
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; }
        public DateTime DtCadastro { get; set; }
        public Guid Codigo { get; set; } = Guid.NewGuid();
    }
}
