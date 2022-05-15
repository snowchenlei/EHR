using Snow.Ehr.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Snow.Ehr.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EhrEntityFrameworkCoreModule),
    typeof(EhrApplicationContractsModule)
    )]
public class EhrDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
