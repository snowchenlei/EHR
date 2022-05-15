using Snow.Ehr.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Snow.Ehr.Permissions;

public class EhrPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EhrPermissions.GroupName);

        var employees = myGroup.AddPermission(EhrPermissions.Employees.Default, L("Permission:Employees"));
        employees.AddChild(EhrPermissions.Employees.Create, L("Permission:Create"));
        employees.AddChild(EhrPermissions.Employees.Update, L("Permission:Edit"));
        employees.AddChild(EhrPermissions.Employees.Delete, L("Permission:Delete"));


        var departments = myGroup.AddPermission(EhrPermissions.Departments.Default, L("Permission:Departments"));
        departments.AddChild(EhrPermissions.Departments.Create, L("Permission:Create"));
        departments.AddChild(EhrPermissions.Departments.Update, L("Permission:Edit"));
        departments.AddChild(EhrPermissions.Departments.Delete, L("Permission:Delete"));


        var emergencyContacts = myGroup.AddPermission(EhrPermissions.EmergencyContacts.Default,
            L("Permission:EmergencyContacts"));
        emergencyContacts.AddChild(EhrPermissions.EmergencyContacts.Create, L("Permission:Create"));
        emergencyContacts.AddChild(EhrPermissions.EmergencyContacts.Update, L("Permission:Edit"));
        emergencyContacts.AddChild(EhrPermissions.EmergencyContacts.Delete, L("Permission:Delete"));


        var workExperiences =
            myGroup.AddPermission(EhrPermissions.WorkExperiences.Default, L("Permission:WorkExperiences"));
        workExperiences.AddChild(EhrPermissions.WorkExperiences.Create, L("Permission:Create"));
        workExperiences.AddChild(EhrPermissions.WorkExperiences.Update, L("Permission:Edit"));
        workExperiences.AddChild(EhrPermissions.WorkExperiences.Delete, L("Permission:Delete"));


        var educationExperiences = myGroup.AddPermission(EhrPermissions.EducationExperiences.Default,
            L("Permission:EducationExperiences"));
        educationExperiences.AddChild(EhrPermissions.EducationExperiences.Create, L("Permission:Create"));
        educationExperiences.AddChild(EhrPermissions.EducationExperiences.Update, L("Permission:Edit"));
        educationExperiences.AddChild(EhrPermissions.EducationExperiences.Delete, L("Permission:Delete"));


        var positions = myGroup.AddPermission(EhrPermissions.Positions.Default, L("Permission:Positions"));
        positions.AddChild(EhrPermissions.Positions.Create, L("Permission:Create"));
        positions.AddChild(EhrPermissions.Positions.Update, L("Permission:Edit"));
        positions.AddChild(EhrPermissions.Positions.Delete, L("Permission:Delete"));

        var organizationUnits = myGroup.AddPermission(EhrPermissions.OrganizationUnits.Default, L("Permission:OrganizationUnits"));
        organizationUnits.AddChild(EhrPermissions.OrganizationUnits.Create, L("Permission:Create"));
        organizationUnits.AddChild(EhrPermissions.OrganizationUnits.Update, L("Permission:Edit"));
        organizationUnits.AddChild(EhrPermissions.OrganizationUnits.Delete, L("Permission:Delete"));


        var salarys = myGroup.AddPermission(EhrPermissions.Salarys.Default, L("Permission:Salarys"));
        salarys.AddChild(EhrPermissions.Salarys.Create, L("Permission:Create"));
        salarys.AddChild(EhrPermissions.Salarys.Update, L("Permission:Edit"));
        salarys.AddChild(EhrPermissions.Salarys.Delete, L("Permission:Delete"));

        var contracts = myGroup.AddPermission(EhrPermissions.Contracts.Default, L("Permission:Contracts"));
        contracts.AddChild(EhrPermissions.Contracts.Create, L("Permission:Create"));
        contracts.AddChild(EhrPermissions.Contracts.Update, L("Permission:Edit"));
        contracts.AddChild(EhrPermissions.Contracts.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EhrResource>(name);
    }
}
