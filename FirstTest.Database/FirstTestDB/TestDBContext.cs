using FirstTest.Core.Account;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace FirstTest.Database.FirstTestDB
{
    public class TestDBContext : DbContext, IPersistedGrantDbContext
    {
        public TestDBContext([NotNull] DbContextOptions<TestDBContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<PersistedGrant> PersistedGrants { get; set; }
        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(e => {
                e.HasKey(p => p.Id);
                e.Property(p => p.FullName).HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            });

            builder.Entity<Address>(e => {
                e.HasKey(p => p.Id);
            });

            builder.Entity<Role>(e => {
                e.HasKey(p => p.Id);
            });

            builder.Entity<PersistedGrant>(e => {
                e.HasKey(p => p.ClientId);
            });

            builder.Entity<DeviceFlowCodes>(e => {
                e.HasKey(p => p.ClientId);
            });

            base.OnModelCreating(builder);
        }
    }
}
