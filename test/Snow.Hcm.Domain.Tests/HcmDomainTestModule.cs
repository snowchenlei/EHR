using Snow.Hcm.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Snow.Hcm
{
    [DependsOn(
        typeof(HcmEntityFrameworkCoreTestModule)
        )]
    public class HcmDomainTestModule : AbpModule
    {

    }
}