using System.Threading.Tasks;

namespace Abp.Test.Data
{
    public interface ITestDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
