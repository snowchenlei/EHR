namespace Snow.Hcm.Permissions
{
    public static class HcmPermissions
    {
        public const string GroupName = "Hcm";

        public static class Employees
        {
            public const string Default = GroupName + ".Employee";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class Departments
        {
            public const string Default = GroupName + ".Department";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class EmergencyContacts
        {
            public const string Default = GroupName + ".EmergencyContact";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class WorkExperiences
        {
            public const string Default = GroupName + ".WorkExperience";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

public static class EducationExperiences
{
public const string Default = GroupName + ".EducationExperience";
public const string Create = Default + ".Create";
public const string Update = Default + ".Update";
public const string Delete = Default + ".Delete";
}
    }
}