using System.Collections.Generic;
using JetBrains.Annotations;

namespace Snow.Hcm.MediaDescriptors
{
    public class MediaDescriptorDefinition : PolicySpecifiedDefinition
    {
        public MediaDescriptorDefinition(
            [NotNull] string entityType,
            IEnumerable<string> createPolicies = null,
            IEnumerable<string> updatePolicies = null,
            IEnumerable<string> deletePolicies = null) : base(entityType,
                                                              createPolicies,
                                                              updatePolicies,
                                                              deletePolicies)
        {
        }
    }
}
