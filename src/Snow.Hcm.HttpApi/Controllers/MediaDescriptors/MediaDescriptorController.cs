using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snow.Hcm.MediaDescriptors;
using Volo.Abp;
using Volo.Abp.Content;
using Volo.Abp.GlobalFeatures;

namespace Snow.Hcm.Controllers.MediaDescriptors
{
    [Area("hcm")]
    [Route("api/hcm/media")]
    public class MediaDescriptorController : HcmController, IMediaDescriptorAppService
    {
        protected readonly IMediaDescriptorAppService MediaDescriptorAppService;

        public MediaDescriptorController(IMediaDescriptorAppService mediaDescriptorAdminAppService)
        {
            MediaDescriptorAppService = mediaDescriptorAdminAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<RemoteStreamContent> DownloadAsync(Guid id)
        {
            return MediaDescriptorAppService.DownloadAsync(id);
        }

        [HttpPost]
        [Route("{entityType}")]
        public virtual Task<MediaDescriptorDto> CreateAsync(string entityType, CreateMediaInputWithStream inputStream)
        {
            return MediaDescriptorAppService.CreateAsync(entityType, inputStream);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return MediaDescriptorAppService.DeleteAsync(id);
        }
    }
}