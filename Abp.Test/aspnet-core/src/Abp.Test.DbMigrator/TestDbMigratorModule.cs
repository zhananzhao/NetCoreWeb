﻿using Abp.Test.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Abp.Test.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(TestEntityFrameworkCoreDbMigrationsModule),
        typeof(TestApplicationContractsModule)
        )]
    public class TestDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
