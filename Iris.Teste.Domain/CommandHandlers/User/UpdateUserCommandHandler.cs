using Iris.Crosscutting.Domain.Bus;
using Iris.Crosscutting.Domain.Commands;
using Iris.Teste.Domain.Commands;
using Iris.Teste.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Iris.Teste.Domain.CommandHandlers
{
    public class UpdateUserCommandHandler : MediatorCommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(
            IMediatorHandler mediator,
            IUserRepository userRepository) : base(mediator)
        {
            _userRepository = userRepository;
        }

        public override async Task AfterValidation(UpdateUserCommand request)
        {
            var registeredUser = await _userRepository.GetOneAsync(x => x.Id == request.Id);

            if (registeredUser == null)
            {
                NotifyError($"O usuário com o código {request.Id} não existe");
                return;
            }

            registeredUser.Name = request.Name;
            registeredUser.Email = request.Email;
            registeredUser.Age = request.Age;

            await _userRepository.UpdateAsync(registeredUser.Id, registeredUser);

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