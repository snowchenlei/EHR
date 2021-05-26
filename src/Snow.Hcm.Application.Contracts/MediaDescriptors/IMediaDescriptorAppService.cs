using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace Snow.Hcm.MediaDescriptors
{
    public interface IMediaDescriptorAppService : IApplicationService
    {
        Task<RemoteStreamContent> DownloadAsync(Guid id);

        Task<MediaDescriptorDto> CreateAsync(string entityType, CreateMediaInputWithStream inputStream);
        
        Task DeleteAsync(Guid id);
    }
}