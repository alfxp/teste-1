using Iris.Crosscutting.Common.Data;
using Iris.Teste.Domain.DataTransferObjects;
using System.Collections.Generic;

namespace Iris.Teste.Domain.Queries
{
    public class GetPagedUserQuery : UserQuery<PagedResult<UserDto>>
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}