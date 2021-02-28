using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Snow.Hcm.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class HcmMigrationsDbContextFactory : IDesignTimeDbContextFactory<HcmMigrationsDbContext>
    {
        public HcmMigrationsDbContext CreateDbContext(string[] args)
        {
            HcmEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<HcmMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new HcmMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Snow.Hcm.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
