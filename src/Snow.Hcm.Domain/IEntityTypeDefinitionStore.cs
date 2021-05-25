using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.DependencyInjection;

namespace Snow.Hcm
{
    public interface IEntityTypeDefinitionStore<TPolicyDefinition> : ITransientDependency
        where TPolicyDefinition : EntityTypeDefinition
    {
        Task<TPolicyDefinition> GetAsync([NotNull] string entityType);

        Task<bool> IsDefinedAsync([NotNull] string entityType);
    }
}
