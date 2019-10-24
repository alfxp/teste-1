using Iris.Crosscutting.Common.Data;
using Iris.Teste.Domain.DataTransferObjects;
using System;
using System.Threading.Tasks;

namespace Iris.Teste.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<PagedResult<UserDto>> GetPagedUsers(int page, int size);
        Task<UserDto> GetUser(Guid userId);
        Task SaveUser(UserDto user, bool update = false);
        Task RemoveUser(Guid id);
    }
}