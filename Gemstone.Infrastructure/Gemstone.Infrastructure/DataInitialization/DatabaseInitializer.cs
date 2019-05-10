using Gemstone.Core.DomainModels;
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
            context.Database.EnsureCreated();

            if (context.Account.Any())
                return;

            // not seeded yet
            var Accounts = new Account[]
            {
                new Account { Name = "Marcin" , IsBusy = true, JoinedOn = DateTime.Parse("2017-09-01") },
                new Account { Name = "Michal" , IsBusy = false, JoinedOn = DateTime.Parse("2015-12-01") },
                new Account { Name = "Pawel" , IsBusy = false, JoinedOn = DateTime.Parse("2018-09-15") },
                new Account { Name = "Marcin" , IsBusy = true, JoinedOn = DateTime.Parse("2017-09-01") },
                new Account { Name = "Michal" , IsBusy = false, JoinedOn = DateTime.Parse("2015-12-01") },
                new Account { Name = "Pawel" , IsBusy = false, JoinedOn = DateTime.Parse("2018-09-15") },
                new Account { Name = "Marcin" , IsBusy = true, JoinedOn = DateTime.Parse("2017-09-01") },
                new Account { Name = "Michal" , IsBusy = false, JoinedOn = DateTime.Parse("2015-12-01") },
                new Account { Name = "Pawel" , IsBusy = false, JoinedOn = DateTime.Parse("2018-09-15") },
            };

            foreach (var Account in Accounts)
                context.Account.Add(Account);

            context.SaveChanges();
        }
    }
}