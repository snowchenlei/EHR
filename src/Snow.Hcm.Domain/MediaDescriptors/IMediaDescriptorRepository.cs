using System;
using Volo.Abp.Domain.Repositories;

namespace Snow.Hcm.MediaDescriptors
{
    public interface IMediaDescriptorRepository : IBasicRepository<MediaDescriptor, Guid>
    {
        
    }
}