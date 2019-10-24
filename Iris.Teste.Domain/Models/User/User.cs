using Iris.Crosscutting.Domain.Model;

namespace Iris.Teste.Domain.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}