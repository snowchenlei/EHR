using Volo.Abp.Modularity;

namespace Snow.Hcm
{
    [DependsOn(
        typeof(HcmApplicationModule),
        typeof(HcmDomainTestModule)
        )]
    public class HcmApplicationTestModule : AbpModule
    {

    }
}