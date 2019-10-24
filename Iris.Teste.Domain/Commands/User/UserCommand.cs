using Iris.Crosscutting.Domain.Commands;
using System;

namespace Iris.Teste.Domain.Commands
{
    public abstract class UserCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}