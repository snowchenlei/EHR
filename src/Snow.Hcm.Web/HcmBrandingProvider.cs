using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Snow.Hcm.Web
{
    [Dependency(ReplaceServices = true)]
    public class HcmBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Hcm";
    }
}
