using Snow.DictionaryManagement;
using Snow.DictionaryManagement.Admin;
using Snow.Media;
using Snow.MenuManagement.Admin;
using Snow.OrganizationUnitManagement;
using Snow.RegionManagement;
using Snow.RegionManagement.Admin;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Snow.Ehr;

[DependsOn(
    typeof(EhrDomainSharedModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpObjectExtendingModule),
    typeof(SnowMediaApplicationContractsModule),
    typeof(SnowOrganizationUnitManagementApplicationContractsModule),
    typeof(SnowMenuManagementApplicationContractsModule),
    typeof(SnowRegionManagementApplicationContractsModule),
    typeof(SnowRegionManagementApplicationContractsSharedModule),
    typeof(SnowDictionaryManagementApplicationContractsModule),
    typeof(SnowDictionaryManagementApplicationContractsSharedModule)
)]
public class EhrApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        EhrDtoExtensions.Configure();
    }
}
