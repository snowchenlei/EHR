using System;
using Microsoft.Extensions.DependencyInjection;
using Snow.DictionaryManagement.EntityFrameworkCore;
using Snow.Media.EntityFrameworkCore;
using Snow.MenuManagement.EntityFrameworkCore;
using Snow.OrganizationUnitManagement.EntityFrameworkCore;
using Snow.RegionManagement.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Snow.Ehr.EntityFrameworkCore;

[DependsOn(
    typeof(EhrDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpIdentityServerEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(SnowMediaEntityFrameworkCoreModule),
    typeof(SnowOrganizationUnitManagementEntityFrameworkCoreModule),
    typeof(SnowMenuManagementEntityFrameworkCoreModule),
    typeof(SnowRegionManagementEntityFrameworkCoreModule),
    typeof(SnowDictionaryManagementEntityFrameworkCoreModule)
    )]
public class EhrEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        EhrEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<EhrDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
                /* The main point to change your DBMS.
                 * See also EhrMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });
    }
}
