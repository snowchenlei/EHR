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
            var administration = context.Menu.GetAdministration();
            if (!MultiTenancyConsts.IsEnabled)
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.GetLocalizer<HcmResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem(HcmMenus.Home, l["Menu:Home"], "~/"));            
            administration.AddItem(
                new ApplicationMenuItem(
                    "EmployeeManagement",
                    l["Menu:EmployeeManagement"],
                    icon: "fa fa-book"
                    ).AddItem(
                    new ApplicationMenuItem(
                        HcmMenus.Employees,
                        l["Menu:Employees"],
                        url: "/Employees"
                        )
                    ).AddItem(
                    new ApplicationMenuItem(
                        HcmMenus.Departments,
                        l["Menu:Departments"],
                        url: "/Departments"
                        )
                    )
            );
        }
    }
}
