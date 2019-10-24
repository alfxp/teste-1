using Iris.Crosscutting.Domain.Bus;
using Iris.Crosscutting.Domain.Commands;
using Iris.Teste.Domain.Commands;
using Iris.Teste.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Iris.Teste.Domain.CommandHandlers
{
    public class RemoveUserCommandHandler : MediatorCommandHandler<RemoveUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserCommandHandler(
            IMediatorHandler mediator,
            IUserRepository userRepository) : base(mediator)
        {
            _userRepository = userRepository;
        }

        public override async Task AfterValidation(RemoveUserCommand request)
        {
            var registeredUser = await _userRepository.ExistsByExpressionAsync(x => x.Name == request.Name);

            if (registeredUser)
            {
                NotifyError($"O usuário com o código {request.Id} não existe");
                return;
            }

            await _userRepository.RemoveAsync(request.Id);

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