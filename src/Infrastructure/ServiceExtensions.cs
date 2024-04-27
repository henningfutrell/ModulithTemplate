using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection InstallModules(
        this IServiceCollection services,
        IConfiguration configuration,
        Action<ModuleInstallerSet> modules
    )
    {
        new ModuleInstallerAgent(
                services,
                configuration
            ).InstallModulesFromSet(modules)
            .InstallModulesFromSet(set => set.Add<BaseInfrastructureInstaller>())
            .AddGlobalMappings();

        return services;
    }
}
