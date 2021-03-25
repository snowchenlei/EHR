using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Snow.Hcm.Localization;
using Snow.Hcm.MultiTenancy;
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
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.GetLocalizer<HcmResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem(HcmMenus.Home, l["Menu:Home"], "~/"));
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    "EmployeeManagement",
                    l["Menu:EmployeeManagement"],
                    icon: "fa fa-book"
                    ).AddItem(
                    new ApplicationMenuItem(
                        "EmployeeManagement.Employees",
                        l["Menu:Employees"],
                        url: "/Employees"
                        )
                    )
            );
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    "Regions",
                    l["Menu:RegionManagement"],
                    icon: "fa fa-book"
                    ).AddItem(
                    new ApplicationMenuItem(
                        "EmployeeManagement.Employees",
                        l["Menu:Regions"],
                        url: "/Regions"
                        )
                    )
            );
        }
    }
}
