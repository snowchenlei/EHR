using Volo.Abp.Modularity;

namespace Snow.Ehr;

[DependsOn(
    typeof(EhrApplicationModule),
    typeof(EhrDomainTestModule)
    )]
public class EhrApplicationTestModule : AbpModule
{

}
