using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Abp.Test.EntityFrameworkCore
{
    public static class TestDbContextModelCreatingExtensions
    {
        public static void ConfigureTest(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(TestConsts.DbTablePrefix + "YourEntities", TestConsts.DbSchema);

            //    //...
            //});
        }
    }
}