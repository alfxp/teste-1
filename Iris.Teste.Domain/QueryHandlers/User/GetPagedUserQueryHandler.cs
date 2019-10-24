using AutoMapper;
using Iris.Crosscutting.Common.Data;
using Iris.Crosscutting.Domain.Bus;
using Iris.Crosscutting.Domain.Queries;
using Iris.Teste.Domain.DataTransferObjects;
using Iris.Teste.Domain.Interfaces.Repositories;
using Iris.Teste.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iris.Teste.Domain.QueryHandlers
{
    public class GetPagedUserQueryHandler : MediatorQueryHandler<GetPagedUserQuery, PagedResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetPagedUserQueryHandler(
            IUserRepository userRepository,
            IMapper mapper,
            IMediatorHandler mediator) : base(mediator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public override async Task<PagedResult<UserDto>> AfterValidation(GetPagedUserQuery request)
        {
            var users = await _userRepository.GetAllPagedAsync(request.Page, request.Size);

            return _mapper.Map<PagedResult<UserDto>>(users);
        }
    }
}