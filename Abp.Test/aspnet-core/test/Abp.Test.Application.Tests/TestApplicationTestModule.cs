﻿using Volo.Abp.Modularity;

namespace Abp.Test
{
    [DependsOn(
        typeof(TestApplicationModule),
        typeof(TestDomainTestModule)
        )]
    public class TestApplicationTestModule : AbpModule
    {

    }
}