using FluentValidation;
using Vendas.Application.Dto;

namespace Vendas.Application.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteDTO>
    {
        public ClienteValidator()
        {
            RuleFor(c =>c.Nome).NotEmpty();
            RuleFor(c => c.Email).NotEmpty().EmailAddress().WithMessage("Email inválido.");
            RuleFor(c => c.Telefone).NotEmpty();
            RuleFor(c => c.Endereco).NotEmpty();
        }
    }
}
