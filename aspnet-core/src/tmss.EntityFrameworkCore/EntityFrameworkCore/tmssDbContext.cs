using Abp.IdentityServer4;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tmss.Authorization.Delegation;
using tmss.Authorization.Roles;
using tmss.Authorization.Users;
using tmss.Chat;
using tmss.Dormitory;
using tmss.Editions;
using tmss.Friendships;
using tmss.MultiTenancy;
using tmss.MultiTenancy.Accounting;
using tmss.MultiTenancy.Payments;
using tmss.Storage;

namespace tmss.EntityFrameworkCore
{
    public class tmssDbContext : AbpZeroDbContext<Tenant, Role, User, tmssDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }
        //public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }
        // New Table Set Here
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InBill> InBills { get; set; }
        public virtual DbSet<OutBill> OutBills { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }


        public tmssDbContext(DbContextOptions<tmssDbContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(150000000);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });
         
        }
    }
}
