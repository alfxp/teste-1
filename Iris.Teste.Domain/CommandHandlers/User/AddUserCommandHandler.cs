using Iris.Crosscutting.Domain.Bus;
using Iris.Crosscutting.Domain.Commands;
using Iris.Teste.Domain.Commands;
using Iris.Teste.Domain.Interfaces.Repositories;
using Iris.Teste.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Iris.Teste.Domain.CommandHandlers
{
    public class AddUserCommandHandler : MediatorCommandHandler<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(
            IMediatorHandler mediator,
            IUserRepository userRepository) : base(mediator)
        {
            _userRepository = userRepository;
        }

        public override async Task AfterValidation(AddUserCommand request)
        {
            var registeredUser = await _userRepository.ExistsByExpressionAsync(x => x.Name == request.Name);

            if (registeredUser)
            {
                NotifyError($"O usuário com o nome {request.Name} já existe");
                return;
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Age = request.Age
            };

            await _userRepository.AddAsync(newUser);

            if (!HasNotification())
            {
                //TODO: EVENTOS PARA CACHE OU FILA
            }
            else
            {
                NotifyError("Commit", "Tivemos um problema ao tentar salvar seus dados.");
            }
        }
    }
}