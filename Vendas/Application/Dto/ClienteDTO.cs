using System.ComponentModel.DataAnnotations;

namespace Vendas.Application.Dto
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Endereco { get; set; }
        public bool StAtivo { get; set; } = true;
    }
}
