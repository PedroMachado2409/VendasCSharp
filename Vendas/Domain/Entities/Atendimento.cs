using System.ComponentModel.DataAnnotations;
using Vendas.Domain.Enum;

namespace Vendas.Domain.Entities
{
    public class Atendimento
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public StAtendimento Status { get; set; }
        public Guid Codigo { get; set; } = Guid.NewGuid();
        public List<Parecer> Pareceres { get; set; } = new List<Parecer>();

    }
}
