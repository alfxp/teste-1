using AutoMapper;
using Iris.Teste.Domain.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Iris.Teste.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();
            AutoMapperConfig.RegisterMappings();
        }
    }
}