using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Snow.Hcm
{
    [Dependency(ReplaceServices = true)]
    public class HcmBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Hcm";
    }
}
