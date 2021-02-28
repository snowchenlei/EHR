using Snow.Hcm.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Snow.Hcm.Blazor
{
    public abstract class HcmComponentBase : AbpComponentBase
    {
        protected HcmComponentBase()
        {
            LocalizationResource = typeof(HcmResource);
        }
    }
}
