using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Snow.Hcm.Localization;
using Snow.Hcm.MultiTenancy;
using Snow.Hcm.Permissions;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Snow.Hcm.Web.Menus
{
    public class HcmMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<HcmResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    HcmMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );

            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }
            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

            administration.AddItem(
                new ApplicationMenuItem(
                    "EmployeeManagement",
                    l["Menu:EmployeeManagement"],
                    icon: "fa fa-book"
                    ).AddItem(
                    new ApplicationMenuItem(
                        HcmMenus.Employees,
                        l["Menu:Employees"],
                        url: "/Employees",
                        requiredPermissionName: HcmPermissions.Employees.Default
                        )
                    ).AddItem(
                    new ApplicationMenuItem(
                        HcmMenus.Departments,
                        l["Menu:Departments"],
                        url: "/Departments",
                        requiredPermissionName: HcmPermissions.Departments.Default
                        )
                    ).AddItem(
                    new ApplicationMenuItem(
                        HcmMenus.OrganizationUnits,
                        l["Menu:OrganizationUnits"],
                        url: "/OrganizationUnitManagement",
                        requiredPermissionName: HcmPermissions.OrganizationUnits.Default
                    )
                ).AddItem(
                    new ApplicationMenuItem(
                        HcmMenus.Positions,
                        l["Menu:Positions"],
                        url: "/Positions",
                        requiredPermissionName: HcmPermissions.Positions.Default
                    )
                )
            );
        }
    }
}
