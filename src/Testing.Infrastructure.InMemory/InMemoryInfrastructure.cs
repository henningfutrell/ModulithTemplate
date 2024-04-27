using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Application.Cqrs.EventSourcing.Writing;
using Modeling.Infrastructure.Abstractions;
using Testing.Infrastructure.InMemory.Events;

namespace Testing.Infrastructure.InMemory;

public sealed class InMemoryInfrastructure 
    : IModuleInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddSingleton<IEventStore, InMemoryEventStore>();
    }
}