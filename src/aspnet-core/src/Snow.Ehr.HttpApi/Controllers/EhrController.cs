using Snow.Ehr.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Snow.Ehr.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EhrController : AbpControllerBase
{
    protected EhrController()
    {
        LocalizationResource = typeof(EhrResource);
    }
}
