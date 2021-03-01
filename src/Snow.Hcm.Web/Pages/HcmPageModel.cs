using Snow.Hcm.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Snow.Hcm.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class HcmPageModel : AbpPageModel
    {
        protected HcmPageModel()
        {
            LocalizationResourceType = typeof(HcmResource);
        }
    }
}