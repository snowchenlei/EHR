using Snow.Hcm.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Snow.Hcm.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(HcmEntityFrameworkCoreDbMigrationsModule),
        typeof(HcmApplicationContractsModule)
        )]
    public class HcmDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
