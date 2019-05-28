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
            // todo fluent API
            modelBuilder.Entity<Account>(BuildAccount);
            //.HasDiscriminator<AccountRole>("AccountRole")
            //.HasValue<Specialist>(AccountRole.Specialist)
            //.HasValue<Assignor>(AccountRole.Assignor);

            modelBuilder.Entity<Assignment>(BuildAssignment);
            //.HasOne<Specialist>(a => a.Specialist)
            //.WithMany(a => a.Assignments);
        }

        private void BuildAccount(EntityTypeBuilder<Account> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasDiscriminator<AccountRole>("AccountRole")
                .HasValue<Specialist>(AccountRole.Specialist)
                .HasValue<Assignor>(AccountRole.Assignor);
        }

        private void BuildAssignment(EntityTypeBuilder<Assignment> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasOne<Specialist>(a => a.Specialist)
                .WithMany(a => a.Assignments);
        }
    }
}