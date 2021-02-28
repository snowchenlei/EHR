using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Snow.Hcm.EntityFrameworkCore
{
    [DependsOn(
        typeof(HcmEntityFrameworkCoreModule)
        )]
    public class HcmEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HcmMigrationsDbContext>();
        }
    }
}
