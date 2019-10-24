using AutoMapper;

namespace Iris.Teste.Domain.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new DomainToDtoMappingProfile());
                config.AddProfile(new DtoToDomainMappingProfile());
            });
        }
    }
}