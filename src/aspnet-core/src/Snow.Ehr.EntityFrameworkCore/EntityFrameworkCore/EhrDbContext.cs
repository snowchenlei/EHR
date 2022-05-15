using Microsoft.EntityFrameworkCore;
using Snow.DictionaryManagement.EntityFrameworkCore;
using Snow.Ehr.EmployeeManagement.ContractAnnexes;
using Snow.Ehr.EmployeeManagement.Contracts;
using Snow.Ehr.EmployeeManagement.EducationExperiences;
using Snow.Ehr.EmployeeManagement.EmergencyContacts;
using Snow.Ehr.EmployeeManagement.Employees;
using Snow.Ehr.EmployeeManagement.Salaries;
using Snow.Ehr.EmployeeManagement.WorkExperiences;
using Snow.Media.EntityFrameworkCore;
using Snow.MenuManagement.EntityFrameworkCore;
using Snow.OrganizationUnitManagement.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Snow.Ehr.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class EhrDbContext :
    AbpDbContext<EhrDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmergencyContact> EmergencyContacts { get; set; }
    public DbSet<WorkExperience> WorkExperiences { get; set; }
    public DbSet<EducationExperience> EducationExperiences { get; set; }
    public DbSet<Salary> Salaries { get; set; }

    public DbSet<Contract> Contracts { get; set; }

    public DbSet<ContractAnnex> ContractAnnexes { get; set; }

    public EhrDbContext(DbContextOptions<EhrDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        builder.ConfigureOrganizationUnitManagement();
        builder.ConfigureMedia();
        builder.ConfigureMenuManagement();
        builder.ConfigureDictionaryManagement();

        #region EmployeeManagement

        builder.Entity<Employee>(b =>
        {
            b.ToTable(EhrConsts.DbTablePrefix + nameof(Employee), EhrConsts.DbSchema);
            b.Property(e => e.Name).HasMaxLength(EmployeeConsts.MaxNameLength);
            b.Property(e => e.EmployeeNumber).HasMaxLength(EmployeeConsts.MaxEmployeeNumberLength);
            b.Property(e => e.PhoneNumber).HasMaxLength(EmployeeConsts.MaxPhoneNumberLength);
            b.Property(e => e.IdCardNumber).HasMaxLength(EmployeeConsts.MaxIdCardNumberLength);
            b.Property(e => e.Address).HasMaxLength(EmployeeConsts.MaxAddressLength);
            b.Property(e => e.BankCardNumber).HasMaxLength(EmployeeConsts.MaxBankCardNumberLength);
            b.Property(e => e.BankOfDeposit).HasMaxLength(EmployeeConsts.MaxBankOfDepositLength);
            b.Property(e => e.ViolationOfLawOrDiscipline).HasMaxLength(EmployeeConsts.MaxViolationOfLawOrDisciplineLength);
            b.Property(e => e.MajorMedicalHistory).HasMaxLength(EmployeeConsts.MaxMajorMedicalHistoryLength);
            b.ConfigureFullAudited();
        });

        builder.Entity<EmergencyContact>(b =>
        {
            b.ToTable(EhrConsts.DbTablePrefix + nameof(EmergencyContact), EhrConsts.DbSchema);
            b.Property(e => e.Name).HasMaxLength(EmergencyContactConsts.MaxNameLength);
            b.Property(e => e.PhoneNumber).HasMaxLength(EmergencyContactConsts.MaxPhoneNumberLength);
            b.Property(e => e.Relation).HasMaxLength(EmergencyContactConsts.MaxRelationLength);
            b.ConfigureCreationTime();
        });

        builder.Entity<WorkExperience>(b =>
        {
            b.ToTable(EhrConsts.DbTablePrefix + nameof(WorkExperience), EhrConsts.DbSchema);
            b.Property(e => e.CompanyName).HasMaxLength(WorkExperienceConsts.MaxCompanyNameLength);
            b.Property(e => e.Post).HasMaxLength(WorkExperienceConsts.MaxPostLength);
            b.Property(e => e.Description).HasMaxLength(WorkExperienceConsts.MaxDescriptionLength);
            b.ConfigureCreationTime();
        });

        builder.Entity<EducationExperience>(b =>
        {
            b.ToTable(EhrConsts.DbTablePrefix + nameof(EducationExperience), EhrConsts.DbSchema);
            b.Property(e => e.SchoolName).HasMaxLength(EducationExperienceConsts.MaxSchoolNameLength);
            b.Property(e => e.Specialty).HasMaxLength(EducationExperienceConsts.MaxSpecialtyLength);
            b.Property(e => e.Description).HasMaxLength(EducationExperienceConsts.MaxDescriptionLength);
            b.ConfigureCreationTime();
        });

        builder.Entity<Contract>(b =>
        {
            b.ToTable(EhrConsts.DbTablePrefix + nameof(Contract), EhrConsts.DbSchema);
            b.Property(e => e.Name).HasMaxLength(ContractConsts.MaxNameLength);
            b.Property(e => e.ContractNumber).HasMaxLength(ContractConsts.MaxContractNumberLength);
        });
        builder.Entity<ContractAnnex>(b =>
        {
            b.ToTable(EhrConsts.DbTablePrefix + nameof(ContractAnnex), EhrConsts.DbSchema);
        });

        builder.Entity<Salary>(b =>
        {
            b.ToTable(EhrConsts.DbTablePrefix + nameof(Salary), EhrConsts.DbSchema);
        });

        #endregion
    }
}
