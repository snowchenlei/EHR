using System;
using System.Collections.Generic;
using System.Text;
using Snow.Hcm.Localization;
using Volo.Abp.Application.Services;

namespace Snow.Hcm
{
    /* Inherit your application services from this class.
     */
    public abstract class HcmAppService : ApplicationService
    {
        protected HcmAppService()
        {
            LocalizationResource = typeof(HcmResource);
        }
    }
}
