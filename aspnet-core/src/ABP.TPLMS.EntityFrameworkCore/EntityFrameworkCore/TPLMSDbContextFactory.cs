using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ABP.TPLMS.Configuration;
using ABP.TPLMS.Web;

namespace ABP.TPLMS.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TPLMSDbContextFactory : IDesignTimeDbContextFactory<TPLMSDbContext>
    {
        public TPLMSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TPLMSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TPLMSDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TPLMSConsts.ConnectionStringName));

            return new TPLMSDbContext(builder.Options);
        }
    }
}
