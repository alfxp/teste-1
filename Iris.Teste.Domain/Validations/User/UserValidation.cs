using FluentValidation;
using Iris.Teste.Domain.Commands;
using System;

namespace Iris.Teste.Domain.Validations
{
    public class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("O código do usuário não pode ser vazio")
                .NotEqual(new Guid()).WithMessage("O código do usuário precisa ser válido")
                .NotNull().WithMessage("O código do usuário não pode ser nulo")
                .NotEmpty().WithMessage("O código do usuário não pode ser vazio");
        }

        protected void Validate()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("O nome do usuário não pode ser nulo")
                .NotEmpty().WithMessage("O nome do usuário não pode ser vazio")
                .MaximumLength(100).WithMessage("O nome do usuário deve conter no máximo 100 caracteres");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("O e-mail do usuário é obrigatório")
                .NotEmpty().WithMessage("O e-mail do usuário é obrigatório")
                .MaximumLength(250).WithMessage("O e-mail do usuário deve conter no máximo 50 caracteres")
                .EmailAddress().WithMessage("O e-mail é inválido");
        }
    }
}