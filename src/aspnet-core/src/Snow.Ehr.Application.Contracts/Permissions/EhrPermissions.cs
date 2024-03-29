﻿namespace Snow.Ehr.Permissions;

public static class EhrPermissions
{
    public const string GroupName = "Ehr";

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

    public static class Positions
    {
        public const string Default = GroupName + ".Position";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class OrganizationUnits
    {
        public const string Default = GroupName + ".OrganizationUnit";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class Salarys
    {
        public const string Default = GroupName + ".Salary";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class Contracts
    {
        public const string Default = GroupName + ".Contract";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
}
