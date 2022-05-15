using System;
using System.Collections.Generic;
using System.Text;
using Snow.Ehr.Localization;
using Volo.Abp.Application.Services;

namespace Snow.Ehr;

/* Inherit your application services from this class.
 */
public abstract class EhrAppService : ApplicationService
{
    protected EhrAppService()
    {
        LocalizationResource = typeof(EhrResource);
    }
}
