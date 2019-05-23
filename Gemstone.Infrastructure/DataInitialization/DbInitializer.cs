using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gemstone.Infrastructure.DataInitialization
{
    public class DbInitializer
    {
        private static Random _gen = new Random();
        private static DateTime _startDate = new DateTime(2000, 1, 1);
        private static int _range = 0;

        private static DateTime RandomDateTime()
        {
            _range = (DateTime.Today - _startDate).Days;
            return _startDate.AddDays(_gen.Next(_range)).AddSeconds(_gen.Next(_range));
        }

        public static void SeedData(EfDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Account.Any())
                return;

            var assignors = new Account[]
            {
                new Assignor { Username = "Rafal", Password = "pass", AccountRole = AccountRole.Assignor, SomeFieldDescribingAssingor = "looking for moto mechanic", JoinedOn = RandomDateTime() },
            };
            foreach (var assignor in assignors)
                context.Account.Add(assignor);

            var specialists = new Account[]
            {
                new Specialist { Username = "Marcin" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",    JoinedOn = RandomDateTime() },
                new Specialist { Username = "Michal" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",    JoinedOn = RandomDateTime() },
                new Specialist { Username = "Pawel" ,AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",      JoinedOn = RandomDateTime() },
                new Specialist { Username = "Grzegorz" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",  JoinedOn = RandomDateTime() },
                new Specialist { Username = "Michal" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",    JoinedOn = RandomDateTime() },
                new Specialist { Username = "Jan" ,AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",        JoinedOn = RandomDateTime() },
                new Specialist { Username = "Jozef" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",     JoinedOn = RandomDateTime() },
                new Specialist { Username = "Marek" , AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",     JoinedOn = RandomDateTime() },
                new Specialist { Username = "Bogdan" ,AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",Password = "specpass",     JoinedOn = RandomDateTime() },
            };

            foreach (var specialist in specialists)
                context.Account.Add(specialist);

            context.SaveChanges();
        }
    }
}