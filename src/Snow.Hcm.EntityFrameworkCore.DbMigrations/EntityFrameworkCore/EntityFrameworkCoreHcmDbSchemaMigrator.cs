using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snow.Hcm.Data;
using Volo.Abp.DependencyInjection;

namespace Snow.Hcm.EntityFrameworkCore
{
    public class EntityFrameworkCoreHcmDbSchemaMigrator
        : IHcmDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreHcmDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the HcmMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<HcmMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}