using System.ComponentModel.DataAnnotations;
using Vendas.Domain.Entities;

namespace Vendas.Application.Dto
{
    public class ReceitaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public DateTime DtCadastro { get; set; } = DateTime.UtcNow;
        public Guid CodigoOrigem { get; set; } = Guid.NewGuid();
        public bool StBaixado { get; set; } = false;
        public double ValorTotal { get; set; } = 0.0;
    }
}
