using System.Runtime.CompilerServices;
using Localization.Resources.AbpUi;
using Snow.DictionaryManagement.Admin;
using Snow.Ehr.Localization;
using Snow.Media;
using Snow.MenuManagement.Admin;
using Snow.OrganizationUnitManagement;
using Snow.RegionManagement.Admin;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Snow.Ehr;

[DependsOn(
    typeof(EhrApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(SnowMediaHttpApiModule),
    typeof(SnowOrganizationUnitManagementHttpApiModule),
    typeof(SnowMenuManagementHttpApiModule),
    typeof(SnowRegionManagementHttpApiModule),
    typeof(SnowDictionaryManagementHttpApiModule)
    )]
public class EhrHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<EhrResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
