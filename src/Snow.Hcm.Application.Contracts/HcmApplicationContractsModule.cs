using Snow.OrganizationUnitManagement;
using Snow.RegionManagement;
using Snow.RegionManagement.Admin;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Snow.Hcm
{
    [DependsOn(
        typeof(HcmDomainSharedModule),
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule),
        typeof(SnowRegionManagementApplicationContractsModule),
        typeof(SnowRegionManagementApplicationContractsSharedModule),
        typeof(OrganizationUnitManagementApplicationContractsModule)
    )]
    public class HcmApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            HcmDtoExtensions.Configure();
        }
    }
}
