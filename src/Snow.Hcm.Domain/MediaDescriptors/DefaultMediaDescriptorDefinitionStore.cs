using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using Volo.Abp;

namespace Snow.Hcm.MediaDescriptors
{
    public class DefaultMediaDescriptorDefinitionStore : IMediaDescriptorDefinitionStore
    {
        protected HcmMediaOptions Options { get; }

        public DefaultMediaDescriptorDefinitionStore(IOptions<HcmMediaOptions> options)
        {
            Options = options.Value;
        }

        /// <summary>
        /// Gets single <see cref="MediaDescriptorDefinition"/> by entityType.
        /// </summary>
        /// <param name="entityType">EntityType to get definition.</param>
        /// <exception cref="EntityCantHaveMediaException">Thrown when EntityType is not configured as taggable.</exception>
        /// <exception cref="InvalidOperationException">More than one element satisfies the condition in predicate.</exception>
        public virtual Task<MediaDescriptorDefinition> GetAsync([NotNull] string entityType)
        {
            Check.NotNullOrWhiteSpace(entityType, nameof(entityType));

            var definition = Options.EntityTypes.SingleOrDefault(
                x => x.EntityType.Equals(entityType, StringComparison.InvariantCultureIgnoreCase)
            ) ?? throw new EntityCantHaveMediaException(entityType);

            return Task.FromResult(definition);
        }

        public virtual Task<bool> IsDefinedAsync([NotNull] string entityType)
        {
            Check.NotNullOrEmpty(entityType, nameof(entityType));

            var isDefined = Options.EntityTypes.Any(
                a => a.EntityType.Equals(entityType, StringComparison.InvariantCultureIgnoreCase)
            );

            return Task.FromResult(isDefined);
        }
    }
}
