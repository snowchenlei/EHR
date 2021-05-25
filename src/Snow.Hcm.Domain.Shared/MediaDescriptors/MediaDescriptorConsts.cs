using System;
using System.Collections.Generic;
using System.Text;
using Snow.Hcm.Entities;

namespace Snow.Hcm.MediaDescriptors
{
    public class MediaDescriptorConsts
    {
        public static int MaxEntityTypeLength { get; set; } = HcmEntityConsts.MaxEntityTypeLength;

        public static int MaxNameLength { get; set; } = 255;

        public static int MaxMimeTypeLength { get; set; } = 128;

        public static int MaxSizeLength = int.MaxValue;
    }
}
