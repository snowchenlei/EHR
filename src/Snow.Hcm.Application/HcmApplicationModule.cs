using System.Collections.Generic;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.MediaDescriptors;
using Snow.Hcm.Permissions;
using Snow.RegionManagement.Admin;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Snow.Hcm
{
    [DependsOn(
        typeof(HcmDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(HcmApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(SnowRegionManagementApplicationModule)
        )]
    public class HcmApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<HcmApplicationModule>();
            });

            Configure<HcmMediaOptions>(options =>
            {
                options.EntityTypes.AddIfNotContains(
                    new MediaDescriptorDefinition(
                        EmployeeConsts.EntityType,
                        createPolicies: new[]
                        {
                            HcmPermissions.Employees.Create,
                            HcmPermissions.Employees.Update
                        },
                        deletePolicies: new[]
                        {
                            HcmPermissions.Employees.Create,
                            HcmPermissions.Employees.Update,
                            HcmPermissions.Employees.Delete
                        }));
            });
        }
    }
}
