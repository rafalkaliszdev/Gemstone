using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Infrastructure.Constants;
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
                .HasDiscriminator<AccountRole>(nameof(AccountRole))
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
                .HasOne(assignment => assignment.Assignor)
                .WithMany(assignor => assignor.Assignments)
                .HasForeignKey(assignment => assignment.AssignorID)
                .OnDelete(DeleteBehavior.Cascade) // remove only when Assignor removes it
                .HasConstraintName(KeyConstants.Assignment_Assignor);

            entityTypeBuilder
                .HasOne(assignment => assignment.Specialist)
                .WithMany(assignor => assignor.Assignments)
                .HasForeignKey(assignment => assignment.SpecialistID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName(KeyConstants.Assignment_Specialist);
        }
    }
}