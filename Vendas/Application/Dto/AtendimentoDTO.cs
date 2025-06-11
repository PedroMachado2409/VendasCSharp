using Vendas.Domain.Enum;

namespace Vendas.Application.Dto
{
    public class AtendimentoDTO
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public int ClienteId { get; set; }
        public string? ClienteNome { get; set; }
        public StAtendimento Status { get; set; }
        public List<ParecerDTO> Pareceres { get; set; } = new List<ParecerDTO>();
    }

    public class ParecerDTO
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public int AtendimentoId { get; set; }
        public int UsuarioId { get; set; }
        public string? UsuarioNome { get; set; }
    }
}
