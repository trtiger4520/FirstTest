using FirstTest.Core.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace FirstTest.Database.FirstTestDB
{
    public class TestDBContext : DbContext
    {
        public TestDBContext([NotNull] DbContextOptions<TestDBContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e => {
                e.HasKey(p => p.Id);
                e.Property(p => p.FullName).HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            });

            modelBuilder.Entity<Address>(e => {
                e.HasKey(p => p.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
