using Clients.API.Application.Commands;
using Clients.API.Data.Repositories;
using Clients.API.Models;
using Core.Mediator;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Clients.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegisterClientCommand, ValidationResult>, ClientCommandHandler>();

            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
