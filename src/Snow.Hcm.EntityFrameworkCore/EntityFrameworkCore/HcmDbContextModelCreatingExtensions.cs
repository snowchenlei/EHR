using Microsoft.EntityFrameworkCore;
using Snow.Hcm.DepartmentManagement.Departments;
using Snow.Hcm.EmployeeManagement.EmergencyContacts;
using Snow.Hcm.EmployeeManagement.Employees;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Snow.Hcm.EntityFrameworkCore
{
    public static class HcmDbContextModelCreatingExtensions
    {
        public static void ConfigureHcm(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            #region EmployeeManagement

            builder.Entity<Employee>(b =>
            {
                b.ToTable(HcmConsts.DbTablePrefix + nameof(Employee), HcmConsts.DbSchema);
                b.Property(e => e.Name).HasMaxLength(EmployeeConsts.MaxNameLength);
                b.Property(e => e.EmployeeNumber).HasMaxLength(EmployeeConsts.MaxEmployeeNumberLength);
                b.Property(e => e.PhoneNumber).HasMaxLength(EmployeeConsts.MaxPhoneNumberLength);
                b.Property(e => e.IdCardNumber).HasMaxLength(EmployeeConsts.MaxIdCardNumberLength);
                b.Property(e => e.Address).HasMaxLength(EmployeeConsts.MaxAddressLength);
                b.ConfigureFullAudited();
            });

            builder.Entity<EmergencyContact>(b =>
            {
                b.ToTable(HcmConsts.DbTablePrefix + nameof(EmergencyContact), HcmConsts.DbSchema);
                b.Property(e => e.Name).HasMaxLength(EmergencyContactConsts.MaxNameLength);
                b.Property(e => e.PhoneNumber).HasMaxLength(EmergencyContactConsts.MaxPhoneNumberLength);
                b.Property(e => e.Relation).HasMaxLength(EmergencyContactConsts.MaxRelationLength);
                b.ConfigureCreationTime();
            });

            #endregion

            #region DepartmentManagement
            builder.Entity<Department>(b =>
            {
                b.ToTable(HcmConsts.DbTablePrefix + nameof(Department), HcmConsts.DbSchema);
                b.Property(e => e.Name).HasMaxLength(DepartmentConsts.MaxNameLength);

                b.ConfigureCreationAudited();
            });
            #endregion
        }
    }
}