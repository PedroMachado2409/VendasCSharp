using System.ComponentModel.DataAnnotations;

namespace Vendas.Application.Dto
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
