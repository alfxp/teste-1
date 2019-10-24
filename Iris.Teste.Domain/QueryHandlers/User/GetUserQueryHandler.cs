using AutoMapper;
using Iris.Crosscutting.Domain.Bus;
using Iris.Crosscutting.Domain.Queries;
using Iris.Teste.Domain.DataTransferObjects;
using Iris.Teste.Domain.Interfaces.Repositories;
using Iris.Teste.Domain.Queries;
using System.Threading.Tasks;

namespace Iris.Teste.Domain.QueryHandlers
{
    public class GetUserQueryHandler : MediatorQueryHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(
            IUserRepository userRepository,
            IMapper mapper,
            IMediatorHandler mediator) : base(mediator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public override async Task<UserDto> AfterValidation(GetUserQuery request)
        {
            var user = await _userRepository.GetOneAsync(x => x.Id == request.Id);

            return _mapper.Map<UserDto>(user);
        }
    }
}