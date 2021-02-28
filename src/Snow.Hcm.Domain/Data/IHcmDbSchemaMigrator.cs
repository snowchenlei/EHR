using System.Threading.Tasks;

namespace Snow.Hcm.Data
{
    public interface IHcmDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
