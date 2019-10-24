using Iris.Teste.Domain.Commands;

namespace Iris.Teste.Domain.Validations
{
    public class RemoveUserValidation : UserValidation<RemoveUserCommand>
    {
        public RemoveUserValidation()
        {
            ValidateId();
        }
    }
}