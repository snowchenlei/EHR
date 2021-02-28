using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Snow.Hcm.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class HcmBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Hcm";
    }
}
