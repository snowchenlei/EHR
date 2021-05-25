using System.ComponentModel.DataAnnotations;
using Volo.Abp.Content;
using Volo.Abp.Validation;

namespace Snow.Hcm.MediaDescriptors
{
    public class CreateMediaInputWithStream
    {
        [Required]
        [DynamicStringLength(typeof(MediaDescriptorConsts), nameof(MediaDescriptorConsts.MaxNameLength))]
        public string Name { get; set; }

        public IRemoteStreamContent File { get; set; }
    }
}