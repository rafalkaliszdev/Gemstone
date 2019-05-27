using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Gemstone.Infrastructure.DataInitialization
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Assignment> Assignment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // todo fluent API
            modelBuilder.Entity<Account>()
                .HasDiscriminator<AccountRole>("AccountRole")
                .HasValue<Specialist>(AccountRole.Specialist)
                .HasValue<Assignor>(AccountRole.Assignor);

            modelBuilder.Entity<Assignment>()
                .HasOne<Specialist>(a => a.Specialist)
                .WithMany(a => a.Assignments);
        }
    }
}