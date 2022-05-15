using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Snow.Ehr;

[Dependency(ReplaceServices = true)]
public class EhrBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Ehr";
}
