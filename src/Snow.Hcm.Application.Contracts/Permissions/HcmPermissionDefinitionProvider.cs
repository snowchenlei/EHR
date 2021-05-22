﻿using Snow.Hcm.Localization;
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


var departments = hcmGroup.AddPermission(HcmPermissions.Departments.Default, L("Permission:Departments"));
departments.AddChild(HcmPermissions.Departments.Create, L("Permission:Create"));
departments.AddChild(HcmPermissions.Departments.Update, L("Permission:Edit"));
departments.AddChild(HcmPermissions.Departments.Delete, L("Permission:Delete"));


var emergencyContacts = hcmGroup.AddPermission(HcmPermissions.EmergencyContacts.Default, L("Permission:EmergencyContacts"));
emergencyContacts.AddChild(HcmPermissions.EmergencyContacts.Create, L("Permission:Create"));
emergencyContacts.AddChild(HcmPermissions.EmergencyContacts.Update, L("Permission:Edit"));
emergencyContacts.AddChild(HcmPermissions.EmergencyContacts.Delete, L("Permission:Delete"));


var workExperiences = hcmGroup.AddPermission(HcmPermissions.WorkExperiences.Default, L("Permission:WorkExperiences"));
workExperiences.AddChild(HcmPermissions.WorkExperiences.Create, L("Permission:Create"));
workExperiences.AddChild(HcmPermissions.WorkExperiences.Update, L("Permission:Edit"));
workExperiences.AddChild(HcmPermissions.WorkExperiences.Delete, L("Permission:Delete"));


var educationExperiences = hcmGroup.AddPermission(HcmPermissions.EducationExperiences.Default, L("Permission:EducationExperiences"));
educationExperiences.AddChild(HcmPermissions.EducationExperiences.Create, L("Permission:Create"));
educationExperiences.AddChild(HcmPermissions.EducationExperiences.Update, L("Permission:Edit"));
educationExperiences.AddChild(HcmPermissions.EducationExperiences.Delete, L("Permission:Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HcmResource>(name);
        }
    }
}
