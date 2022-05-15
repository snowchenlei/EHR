using Snow.DictionaryManagement.Admin;
using Snow.Media;
using Snow.MenuManagement.Admin;
using Snow.OrganizationUnitManagement;
using Snow.RegionManagement.Admin;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Snow.Ehr;

[DependsOn(
    typeof(EhrDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(EhrApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(SnowMediaApplicationModule),
    typeof(SnowOrganizationUnitManagementApplicationModule),
    typeof(SnowMenuManagementApplicationModule),
    typeof(SnowRegionManagementApplicationModule),
    typeof(SnowDictionaryManagementApplicationModule)
        )]
public class EhrApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<EhrApplicationModule>();
        });
    }
}
