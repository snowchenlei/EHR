using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Snow.Hcm.MediaDescriptors
{
    public interface IMediaDescriptorAppService : IApplicationService
    {
        Task<MediaDescriptorDto> CreateAsync(string entityType, CreateMediaInputWithStream inputStream);
        
        Task DeleteAsync(Guid id);
    }
}