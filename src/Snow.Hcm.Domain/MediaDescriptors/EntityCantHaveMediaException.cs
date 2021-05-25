using System.Runtime.Serialization;
using Volo.Abp;

namespace Snow.Hcm.MediaDescriptors
{
    public class EntityCantHaveMediaException : BusinessException
    {
        public EntityCantHaveMediaException(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context)
        {
        }

        public EntityCantHaveMediaException(string entityType)
          : base(code: HcmErrorCodes.MediaDescriptors.EntityTypeDoesntExist)
        {
            EntityType = entityType;
            WithData(nameof(entityType), EntityType);
        }

        public string EntityType { get; }
    }
}
