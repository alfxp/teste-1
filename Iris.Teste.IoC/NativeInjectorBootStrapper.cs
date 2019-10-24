using Iris.Crosscutting.Bus;
using Iris.Crosscutting.Common.Data;
using Iris.Crosscutting.Domain.Bus;
using Iris.Crosscutting.Domain.Notifications;
using Iris.Teste.Domain.CommandHandlers;
using Iris.Teste.Domain.Commands;
using Iris.Teste.Domain.DataTransferObjects;
using Iris.Teste.Domain.Interfaces.Repositories;
using Iris.Teste.Domain.Interfaces.Services;
using Iris.Teste.Domain.Queries;
using Iris.Teste.Domain.QueryHandlers;
using Iris.Teste.Domain.Services;
using Iris.Teste.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Iris.Teste.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //EXEMPLO DE INJEÇÃO DE EVENTS
            //services.AddScoped<INotificationHandler<AddedEvent>, EventHandler>();
            //services.AddScoped<INotificationHandler<UpdatedEvent>, EventHandler>();
            //services.AddScoped<INotificationHandler<RemovedEvent>, EventHandler>();


            // Domain - Commands

            //EXEMPLO DE INJEÇÃO DE COMMANDS
            //services.AddScoped<IRequestHandler<AddCommand, Unit>, AddCommandHandler>();
            //services.AddScoped<IRequestHandler<UpdateCommand, Unit>, UpdateCommandHandler>();
            //services.AddScoped<IRequestHandler<RemoveCommand, Unit>, RemoveCommandHandler>();

            services.AddScoped<IRequestHandler<AddUserCommand, Unit>, AddUserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, Unit>, UpdateUserCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUserCommand, Unit>, RemoveUserCommandHandler>();

            // Domain - Queries

            //EXEMPLO DE INJEÇÃO DE QUERIES
            //services.AddScoped<IRequestHandler<GetQuery, Dto>, GetQueryHandler>();
            //services.AddScoped<IRequestHandler<GetPagedQuery, PagedResult<Dto>>, GetPagedUsersQueryHandler>();

            services.AddScoped<IRequestHandler<GetUserQuery, UserDto>, GetUserQueryHandler>();
            services.AddScoped<IRequestHandler<GetPagedUserQuery, PagedResult<UserDto>>, GetPagedUserQueryHandler>();

            // Services

            services.AddScoped<IUserService, UserService>();

            // Infra - Data

            //EXEMPLO DE INJEÇÃO DE REPOSITORIOS
            //services.AddScoped<IRepository, Repository>();

            services.AddScoped<IUserRepository, UserRepository>();

            // Helper injecting claims
            services.AddTransient(s => s.GetService<IHttpContextAccessor>().HttpContext.User);

            // Mediator pipelines

            //EXEMPLO DE INJEÇÃO DE MEDIATOR PIPELINES
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        }
    }
}