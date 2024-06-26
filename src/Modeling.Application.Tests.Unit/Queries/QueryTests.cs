using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Application.Cqrs.Queries;
using Modeling.Application.Tests.Unit.Queries.TestApplication;

namespace Modeling.Application.Tests.Unit.Queries;

public sealed class QueryTests
{
    private readonly IServiceProvider _serviceProvider;
    private const int GoodResult = 1;

    public QueryTests()
    {
        _serviceProvider = new ServiceCollection()
                .AddMediatR(c => 
                    c.RegisterServicesFromAssemblies([typeof(ThingStore).Assembly]))
                .InstallModules(null, set => 
                    set.Add<ApplicationTestModuleInstaller>()
                )
                .BuildServiceProvider()
            ;
    }

    private async Task<int> RunGoodQuery()
    {
        var result = await _serviceProvider.GetService<IQueryBus>()!.SendQuery<ThingQuery, ThingQueryResult>(new ThingQuery(0));
        return result.SuccessValue.ThingGotten;
    }

    [Fact]
    public async Task gets_the_thing()
    {
        var result = await RunGoodQuery();
        Assert.Equal(GoodResult, result);
    }
}