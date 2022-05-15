using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Snow.Ehr.Data;

/* This is used if database provider does't define
 * IEhrDbSchemaMigrator implementation.
 */
public class NullEhrDbSchemaMigrator : IEhrDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
