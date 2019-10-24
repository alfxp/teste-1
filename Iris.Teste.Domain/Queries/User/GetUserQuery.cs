using Iris.Teste.Domain.DataTransferObjects;

namespace Iris.Teste.Domain.Queries
{
    public class GetUserQuery : UserQuery<UserDto>
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}