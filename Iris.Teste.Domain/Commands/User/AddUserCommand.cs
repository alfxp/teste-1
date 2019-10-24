using Iris.Teste.Domain.Validations;

namespace Iris.Teste.Domain.Commands
{
    public class AddUserCommand : UserCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new AddUserValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}