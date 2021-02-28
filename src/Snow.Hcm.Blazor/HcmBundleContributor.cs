using Volo.Abp.Bundling;

namespace Snow.Hcm.Blazor
{
    public class HcmBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css", true);
        }
    }
}