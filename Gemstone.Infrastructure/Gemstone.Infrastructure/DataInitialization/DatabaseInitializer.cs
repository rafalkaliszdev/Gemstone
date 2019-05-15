using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gemstone.Infrastructure.DataInitialization
{
    public static class DatabaseInitializer
    {
        public static void Initialize(GemstoneDbContext context)
        {
            // todo for testing - im going often to create and recreate db
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            if (context.Account.Any())
                return;

            // not seeded yet

            var assignors = new Account[]
            {
                new Assignor { UserName = "Rafal", Password = "pass", AccountRole = AccountRole.AssignorRole, SomeFieldDescribingAssingor = "looking for moto mechanic", JoinedOn = DateTime.Parse("2019-05-14") },
            };
            foreach (var assignor in assignors)
                context.Account.Add(assignor);

            var specialists = new Account[]
            {
                new Specialist { UserName = "Marcin" , AccountRole = AccountRole.SpecialistRole,CraftAreaName = "motorcycles",  Password = "specpass",  JoinedOn = DateTime.Parse("2017-09-01") },
                new Specialist { UserName = "Michal" , AccountRole = AccountRole.SpecialistRole,CraftAreaName = "motorcycles",  Password = "specpass",   JoinedOn = DateTime.Parse("2015-12-01") },
                new Specialist { UserName = "Pawel" ,  AccountRole = AccountRole.SpecialistRole,CraftAreaName = "motorcycles",  Password = "specpass",  JoinedOn = DateTime.Parse("2018-09-15") },
                new Specialist { UserName = "Grzegorz" , AccountRole = AccountRole.SpecialistRole,CraftAreaName = "motorcycles",  Password = "specpass",  JoinedOn = DateTime.Parse("2017-09-01") },
                new Specialist { UserName = "Michal" , AccountRole = AccountRole.SpecialistRole,CraftAreaName = "motorcycles",  Password = "specpass",   JoinedOn = DateTime.Parse("2015-05-01") },
                new Specialist { UserName = "Jan" ,  AccountRole = AccountRole.SpecialistRole,CraftAreaName = "motorcycles",  Password = "specpass",  JoinedOn = DateTime.Parse("2018-09-15") },
                new Specialist { UserName = "Jozef" , AccountRole = AccountRole.SpecialistRole,CraftAreaName = "motorcycles",  Password = "specpass",  JoinedOn = DateTime.Parse("2011-09-01") },
                new Specialist { UserName = "Marek" , AccountRole = AccountRole.SpecialistRole,CraftAreaName = "motorcycles",  Password = "specpass",   JoinedOn = DateTime.Parse("2015-12-01") },
                new Specialist { UserName = "Bogdan" ,  AccountRole = AccountRole.SpecialistRole,CraftAreaName = "motorcycles",  Password = "specpass",  JoinedOn = DateTime.Parse("2018-09-15") },
            };

            foreach (var specialist in specialists)
                context.Account.Add(specialist);

            context.SaveChanges();
        }
    }
}