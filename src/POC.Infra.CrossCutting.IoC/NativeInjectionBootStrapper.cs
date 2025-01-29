using FluentValidation.Results;
using MediatR;
using NetDevPack.Mediator;
using POC.Domain.Commands;
using POC.Domain.Events;
using POC.Domain.Interfaces;
using POC.Infra.CrossCutting.Bus;
using POC.Infra.Data.Context;
using POC.Infra.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using POC.Infra.Data.EventSourcing;

namespace POC.Infra.CrossCutting.IoC
{
    public static class NativeInjectionBootStrapper
    {
        public static void RegisterServices(WebApplicationBuilder builder) {

            //Mediator Handler
            builder.Services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Events
            builder.Services.AddScoped<INotificationHandler<ClientRegisteredEvent>, ClientEventHandler>();
            //builder.Services.AddScoped<INotificationHandler<ClientUpdatedEvent>, ClientEventHandler>();
            //builder.Services.AddScoped<INotificationHandler<ClientRemovedEvent>, ClientEventHandler>();

            // Domain - Commands
            builder.Services.AddScoped<IRequestHandler<RegisterNewClientCommand, ValidationResult>, ClientCommandHandler>();
            //builder.Services.AddScoped<IRequestHandler<UpdateClientCommand, ValidationResult>, ClientCommandHandler>();
            //builder.Services.AddScoped<IRequestHandler<RemoveClientCommand, ValidationResult>, ClientCommandHandler>();

            // Infra - Data
            builder.Services.AddScoped<IClientRepository, ClientReposiroty>();
            builder.Services.AddScoped<POCContext>();

            // Infra - Data EventSourcing
            builder.Services.AddScoped<IEventStore, SqlEventStore>();
            //builder.Services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            //builder.Services.AddScoped<EventStoreSqlContext>();
        }
    }
}
