using FirstTest.Core.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace FirstTest.Database.FirstTestDB
{
    public class TestDBContext : DbContext
    {
        public TestDBContext([NotNull] DbContextOptions<TestDBContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Address { get; set; }

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

            base.OnModelCreating(builder);
        }
    }
}
