using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.MediaDescriptors
{
    [Serializable]
    public class MediaDescriptorDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        
        public string MimeType { get; set; }

        public int Size { get; set; }
    }
}