using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gemstone.Infrastructure.DataAccess
{
    class GemstoneDbContext : DbContext
    {
        public GemstoneDbContext(DbContextOptions<GemstoneDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Tree { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Account>().tab("Account");
        }
    }
}