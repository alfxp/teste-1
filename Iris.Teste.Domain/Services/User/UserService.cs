using AutoMapper;
using Iris.Crosscutting.Common.Data;
using Iris.Crosscutting.Domain.Bus;
using Iris.Teste.Domain.Commands;
using Iris.Teste.Domain.DataTransferObjects;
using Iris.Teste.Domain.Interfaces.Services;
using Iris.Teste.Domain.Queries;
using System;
using System.Threading.Tasks;

namespace Iris.Teste.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public UserService(
            IMapper mapper,
            IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<PagedResult<UserDto>> GetPagedUsers(int page, int size)
        {
            var query = new GetPagedUserQuery { Page = page, Size = size };
            var pagedUsers = await _mediator.SendQuery(query);

            return pagedUsers;
        }

        public async Task<UserDto> GetUser(Guid userId)
        {
            var query = new GetUserQuery { Id = userId };
            var user = await _mediator.SendQuery(query);

            return user;
        }

        public async Task SaveUser(UserDto user, bool update = false)
        {
            if (!update)
            {
                var command = _mapper.Map<AddUserCommand>(user);
                await _mediator.SendCommand(command);
            }
            else
            {
                var command = _mapper.Map<UpdateUserCommand>(user);
                await _mediator.SendCommand(command);
            }
        }

        public async Task RemoveUser(Guid id)
        {
            var command = new RemoveUserCommand(id);
            await _mediator.SendCommand(command);
        }
    }
}