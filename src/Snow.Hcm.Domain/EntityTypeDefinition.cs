using System;
using JetBrains.Annotations;
using Volo.Abp;

namespace Snow.Hcm
{
    public abstract class EntityTypeDefinition : IEquatable<EntityTypeDefinition>
    {
        public EntityTypeDefinition([NotNull] string entityType)
        {
            EntityType = Check.NotNullOrEmpty(entityType, nameof(entityType));
        }

        [NotNull]
        public string EntityType { get; protected set; }

        public bool Equals(EntityTypeDefinition other)
        {
            return EntityType == other?.EntityType;
        }
    }
}
