using System.Threading.Tasks;

namespace Snow.Ehr.Data;

public interface IEhrDbSchemaMigrator
{
    Task MigrateAsync();
}
