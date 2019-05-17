﻿using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Gemstone.Infrastructure.DataInitialization
{
    public class GemstoneDbContext : DbContext
    {
        public GemstoneDbContext(DbContextOptions<GemstoneDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // todo consider adding domain model data annotation fluent API
            modelBuilder.Entity<Account>()
                .HasDiscriminator<AccountRole>("AccountRole")
                .HasValue<Specialist>(AccountRole.Specialist)
                .HasValue<Assignor>(AccountRole.Assignor);
        }
    }
}