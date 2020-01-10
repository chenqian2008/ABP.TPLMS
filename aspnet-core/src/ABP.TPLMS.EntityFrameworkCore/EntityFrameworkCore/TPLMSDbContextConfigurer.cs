using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ABP.TPLMS.EntityFrameworkCore
{
    public static class TPLMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TPLMSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TPLMSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
