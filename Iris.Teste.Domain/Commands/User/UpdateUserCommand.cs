using Iris.Teste.Domain.Validations;

namespace Iris.Teste.Domain.Commands
{
    public class UpdateUserCommand : UserCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateUserValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}