using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gemstone.Infrastructure.DataInitialization
{
    public static class DbInitializer
    {
        public static void SeedData(EfDbContext context)
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            if (context.Account.Any())
                return;

            // not seeded yet

            var assignors = new Account[]
            {
                new Assignor { Username = "Rafal", Password = "pass", AccountRole = AccountRole.Assignor, SomeFieldDescribingAssingor = "looking for moto mechanic", JoinedOn = DateTime.Parse("2019-05-14") },
            };
            foreach (var assignor in assignors)
                context.Account.Add(assignor);

            var specialists = new Account[]
            {
                new Specialist { Username = "Marcin" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",JoinedOn = DateTime.Parse("2017-09-01") },
                new Specialist { Username = "Michal" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass", JoinedOn = DateTime.Parse("2015-12-01") },
                new Specialist { Username = "Pawel" ,AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",JoinedOn = DateTime.Parse("2018-09-15") },
                new Specialist { Username = "Grzegorz" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",JoinedOn = DateTime.Parse("2017-09-01") },
                new Specialist { Username = "Michal" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass", JoinedOn = DateTime.Parse("2015-05-01") },
                new Specialist { Username = "Jan" ,AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",JoinedOn = DateTime.Parse("2018-09-15") },
                new Specialist { Username = "Jozef" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",JoinedOn = DateTime.Parse("2011-09-01") },
                new Specialist { Username = "Marek" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass", JoinedOn = DateTime.Parse("2015-12-01") },
                new Specialist { Username = "Bogdan" ,AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",JoinedOn = DateTime.Parse("2018-09-15") },
            };

            foreach (var specialist in specialists)
                context.Account.Add(specialist);

            context.SaveChanges();
        }
    }
}