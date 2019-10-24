using Iris.Crosscutting.Domain.Interfaces.Repositories;
using Iris.Teste.Domain.Models;

namespace Iris.Teste.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IMongoDbRepository<User>
    {
    }
}