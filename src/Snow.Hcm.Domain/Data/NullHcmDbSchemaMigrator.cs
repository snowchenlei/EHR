using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Snow.Hcm.Data
{
    /* This is used if database provider does't define
     * IHcmDbSchemaMigrator implementation.
     */
    public class NullHcmDbSchemaMigrator : IHcmDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}