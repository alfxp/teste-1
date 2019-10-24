using Iris.Teste.Domain.Commands;

namespace Iris.Teste.Domain.Validations
{
    public class UpdateUserValidation : UserValidation<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            ValidateId();
            Validate();
        }
    }
}