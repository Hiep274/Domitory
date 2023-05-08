using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace tmss.EntityFrameworkCore
{
    public static class tmssDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<tmssDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<tmssDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}