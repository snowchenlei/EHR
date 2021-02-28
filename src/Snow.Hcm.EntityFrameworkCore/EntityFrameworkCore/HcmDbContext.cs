using Microsoft.EntityFrameworkCore;
using Snow.Hcm.EmployeeManagement.EmergencyContacts;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Snow.Hcm.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See HcmMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class HcmDbContext : AbpDbContext<HcmDbContext>
    {
        public DbSet<AppUser> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside HcmDbContextModelCreatingExtensions.ConfigureHcm
         */

        public HcmDbContext(DbContextOptions<HcmDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the HcmEfCoreEntityExtensionMappings class
                 */
            });

            /* Configure your own tables/entities inside the ConfigureHcm method */

            builder.ConfigureHcm();
        }
    }
}
