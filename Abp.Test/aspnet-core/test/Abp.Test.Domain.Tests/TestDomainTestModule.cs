using Abp.Test.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Abp.Test
{
    [DependsOn(
        typeof(TestEntityFrameworkCoreTestModule)
        )]
    public class TestDomainTestModule : AbpModule
    {

    }
}