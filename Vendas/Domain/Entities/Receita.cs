using System.ComponentModel.DataAnnotations;

namespace Vendas.Domain.Entities
{
    public class Receita
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public DateTime DtCadastro { get; set; } = DateTime.UtcNow;
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public bool StBaixado { get; set; } = false;
        public double ValorTotal { get; set; } = 0.0;
        public Guid CodigoOrigem { get; set; } = Guid.NewGuid();

    }
}
