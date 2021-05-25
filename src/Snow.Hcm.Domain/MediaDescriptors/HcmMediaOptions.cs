using System.Collections.Generic;
using JetBrains.Annotations;

namespace Snow.Hcm.MediaDescriptors
{
    public class HcmMediaOptions
    {
        [NotNull]
        public List<MediaDescriptorDefinition> EntityTypes { get; } = new();
    }
}
