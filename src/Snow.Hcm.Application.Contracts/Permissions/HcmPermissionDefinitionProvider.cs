using Snow.Hcm.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Snow.Hcm.Permissions
{
    public class HcmPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var hcmGroup = context.AddGroup(HcmPermissions.GroupName);
            
            var employees = hcmGroup.AddPermission(HcmPermissions.Employees.Default, L("Permission:Employees"));
            employees.AddChild(HcmPermissions.Employees.Create, L("Permission:Create"));
            employees.AddChild(HcmPermissions.Employees.Update, L("Permission:Edit"));
            employees.AddChild(HcmPermissions.Employees.Delete, L("Permission:Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HcmResource>(name);
        }
    }
}
