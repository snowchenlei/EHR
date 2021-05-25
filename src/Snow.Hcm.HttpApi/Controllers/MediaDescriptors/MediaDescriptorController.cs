using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snow.Hcm.MediaDescriptors;
using Volo.Abp;
using Volo.Abp.GlobalFeatures;

namespace Snow.Hcm.Controllers.MediaDescriptors
{
    [Area("hcm")]
    [Route("api/hcm/media")]
    public class MediaDescriptorController : HcmController, IMediaDescriptorAppService
    {
        protected readonly IMediaDescriptorAppService MediaDescriptorAdminAppService;

        public MediaDescriptorController(IMediaDescriptorAppService mediaDescriptorAdminAppService)
        {
            MediaDescriptorAdminAppService = mediaDescriptorAdminAppService;
        }

        [HttpPost]
        [Route("{entityType}")]
        public virtual Task<MediaDescriptorDto> CreateAsync(string entityType, CreateMediaInputWithStream inputStream)
        {
            return MediaDescriptorAdminAppService.CreateAsync(entityType, inputStream);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return MediaDescriptorAdminAppService.DeleteAsync(id);
        }
    }
}