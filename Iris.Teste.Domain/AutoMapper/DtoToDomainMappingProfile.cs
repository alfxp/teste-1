using AutoMapper;
using Iris.Teste.Domain.Commands;
using Iris.Teste.Domain.DataTransferObjects;

namespace Iris.Teste.Domain.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<UserDto, AddUserCommand>();
            CreateMap<UserDto, UpdateUserCommand>();
            CreateMap<UserDto, RemoveUserCommand>();
        }
    }
}