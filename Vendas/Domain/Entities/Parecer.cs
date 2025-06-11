using System.ComponentModel.DataAnnotations;

namespace Vendas.Domain.Entities
{
    public class Parecer
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataHora { get; set; } = DateTime.UtcNow;
        public int AtendimentoId { get; set; }
        public Atendimento? Atendimento { get; set; }
        public Guid Codigo { get; set; } = Guid.NewGuid();
        public Usuario? Usuario { get; set; } 
        public int UsuarioId { get; set; } 
    }
}
