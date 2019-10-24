using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Iris.Teste.Api.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                s.SwaggerDoc("v1",
                    new Info
                    {
                        Version = "v1",
                        Title = "Iris Teste API",
                        Description = "Iris Teste API",

                    }
                );

                var location = Assembly.GetEntryAssembly().Location;
                var directory = Path.GetDirectoryName(location);
                var xmlPath = Path.Combine(directory, "Iris.Teste.Api.xml");

                s.IncludeXmlComments(xmlPath);
            });
        }
    }
}