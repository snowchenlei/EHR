using Snow.Hcm.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Snow.Hcm.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class HcmController : AbpController
    {
        protected HcmController()
        {
            LocalizationResource = typeof(HcmResource);
        }
    }
}