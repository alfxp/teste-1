using Iris.Crosscutting.Infrastructure.Contexts.MongoDb;
using Iris.Crosscutting.Infrastructure.Repositories;
using Iris.Teste.Domain.Interfaces.Repositories;
using Iris.Teste.Domain.Models;

namespace Iris.Teste.Infrastructure.Repositories
{
    public class UserRepository : MongoRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDbContext context, string collectionName = "users")
            : base(collectionName, context) { }
    }
}