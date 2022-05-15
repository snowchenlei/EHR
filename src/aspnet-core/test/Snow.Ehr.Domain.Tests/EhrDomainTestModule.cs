using Snow.Ehr.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Snow.Ehr;

[DependsOn(
    typeof(EhrEntityFrameworkCoreTestModule)
    )]
public class EhrDomainTestModule : AbpModule
{

}
