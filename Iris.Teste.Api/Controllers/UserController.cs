using AutoMapper;
using Iris.Crosscutting.Domain.Bus;
using Iris.Crosscutting.Domain.Controller;
using Iris.Teste.Domain.DataTransferObjects;
using Iris.Teste.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Iris.Teste.Api.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(
            IMediatorHandler mediator,
            IUserService userService,
            IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
            _userService = userService;
        }

        /// <summary>
        /// Efetua consulta paginada dos usuários
        /// </summary>
        /// <param name="page">Página atual</param>
        /// <param name="size">Quantidade de registros por página</param>
        /// <returns>Lista paginada de usuários</returns>
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int size = 20)
        {
            var users = await _userService.GetPagedUsers(page, size);

            return Response(users);
        }

        /// <summary>
        /// Efetua consulta de um usuário pelo código
        /// </summary>
        /// <param name="id">Código do usuário</param>
        /// <returns>Usuário encontrado</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userService.GetUser(Guid.Parse(id));

            return Response(user);
        }

        /// <summary>
        /// Efetua o cadastro de um novo usuário
        /// </summary>
        /// <param name="user">Dados do usuário</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {
            await _userService.SaveUser(user);

            return Response();
        }

        /// <summary>
        /// Efetua a atualização de um usuário
        /// </summary>
        /// <param name="user">Dados do usuário</param>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDto user)
        {
            await _userService.SaveUser(user, update: true);

            return Response();
        }

        /// <summary>
        /// Efetua a exclusão de um usuário pelo código
        /// </summary>
        /// <param name="id">Código do usuário</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.RemoveUser(Guid.Parse(id));

            return Response();
        }
    }
}