using AutoMapper;
using Iris.Teste.Domain.DataTransferObjects;
using Iris.Teste.Domain.Models;

namespace Iris.Teste.Domain.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}