using System.ComponentModel.DataAnnotations;
using System.IO;
using Volo.Abp.Content;
using Volo.Abp.Validation;

namespace Snow.Hcm.MediaDescriptors
{
    public class CreateMediaInputStream : RemoteStreamContent
    {
        [Required]
        [DynamicStringLength(typeof(MediaDescriptorConsts), nameof(MediaDescriptorConsts.MaxEntityTypeLength))]
        public string EntityType { get; set; }
        
        [Required]
        [DynamicStringLength(typeof(MediaDescriptorConsts), nameof(MediaDescriptorConsts.MaxNameLength))]
        public string Name { get; set; }

        public CreateMediaInputStream(Stream stream) : base(stream)
        {
        }
    }
}