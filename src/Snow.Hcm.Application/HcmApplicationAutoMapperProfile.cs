using AutoMapper;
using Snow.Hcm.MediaDescriptors;

namespace Snow.Hcm
{
    public class HcmApplicationAutoMapperProfile : Profile
    {
        public HcmApplicationAutoMapperProfile()
        {
            CreateMap<MediaDescriptor, MediaDescriptorDto>();
        }
    }
}
