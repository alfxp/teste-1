using Iris.Teste.Domain.Commands;

namespace Iris.Teste.Domain.Validations
{
    public class AddUserValidation : UserValidation<AddUserCommand>
    {
        public AddUserValidation()
        {
            Validate();
        }
    }
}