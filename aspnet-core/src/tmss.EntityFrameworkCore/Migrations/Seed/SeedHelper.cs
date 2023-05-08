using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Transactions;
using tmss.EntityFrameworkCore;
using tmss.Migrations.Seed.Tenants;

namespace tmss.Migrations.Seed
{
    public static class SeedHelper
    {
        public static void SeedHostDb(IIocResolver iocResolver)
        {
            WithDbContext<tmssDbContext>(iocResolver, SeedHostDb);
        }

        public static void SeedHostDb(tmssDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            //Host seed
            //new InitialHostDbBuilder(context).Create();

            //Default tenant seed (in host database).
            new DefaultTenantBuilder(context).Create();
            new TenantRoleAndUserBuilder(context, 1).Create();



            //const string MIGRATION_SQL_SCRIPT_FILE_NAME = @"data_scripts\data.sql";
            //string parentDir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            //int index = parentDir.IndexOf("bin");
            //string dir = parentDir.Substring(0, index - 1);
            //string sql = Path.Combine(dir, MIGRATION_SQL_SCRIPT_FILE_NAME);
            //migrationBuilder.Sql(File.ReadAllText(sql));
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}
