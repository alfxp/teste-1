using Iris.Crosscutting.Domain.Queries;
using System;

namespace Iris.Teste.Domain.Queries
{
    public abstract class UserQuery<TResponse> : Query<TResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public Guid Id { get; set; }
    }
}