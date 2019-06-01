using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gemstone.Infrastructure.DataInitialization
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options) { }

        public DbSet<Account> Account { get; set; }
        public DbSet<Assignment> Assignment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(BuildAccount);

            modelBuilder.Entity<Assignment>(BuildAssignment);
        }

        private void BuildAccount(EntityTypeBuilder<Account> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasDiscriminator<AccountRole>("AccountRole")
                .HasValue<Specialist>(AccountRole.Specialist)
                .HasValue<Assignor>(AccountRole.Assignor);
            entityTypeBuilder
                .Property(acc => acc.Username)
                .HasMaxLength(40)
                .IsRequired();
        }

        private void BuildAssignment(EntityTypeBuilder<Assignment> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasOne<Specialist>(a => a.Specialist)
                .WithMany(a => a.Assignments);
        }
    }
}