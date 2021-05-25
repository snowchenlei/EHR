using System;
using Snow.Hcm.MediaDescriptors;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Snow.Hcm.EntityFrameworkCore.MediaDescriptors
{
    public class EfCoreMediaDescriptorRepository : EfCoreRepository<HcmDbContext, MediaDescriptor, Guid>, IMediaDescriptorRepository
    {
        public EfCoreMediaDescriptorRepository(IDbContextProvider<HcmDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}