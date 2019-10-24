using Iris.Teste.Domain.Validations;
using System;

namespace Iris.Teste.Domain.Commands
{
    public class RemoveUserCommand : UserCommand
    {
        public RemoveUserCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUserValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}