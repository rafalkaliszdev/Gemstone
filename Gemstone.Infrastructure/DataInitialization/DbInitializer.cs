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
        private static Random _random = new Random();
        private static DateTime _startDate = new DateTime(2000, 1, 1);
        private static int _range = 0;
        private static bool _recreateDb = false;

        public static void SeedData(EfDbContext context)
        {
            if (_recreateDb)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            if (context.Account.Any())
                return;

            SeedAccounts(context);
            SeedAssignments(context);

            context.SaveChanges();
        }

        private static void SeedAccounts(EfDbContext context)
        {
            var assignors = new Account[]
            {
                new Assignor { Username = "Rafal", Password = "pass", AccountRole = AccountRole.Assignor, SomeFieldDescribingAssingor = "looking for moto mechanic", JoinedOn = RandomDateTime() },
            };
            foreach (var assignor in assignors)
                context.Account.Add(assignor);

            var specialists = new Account[]
            {
                new Specialist { Username = "Marcin" ,  Password = "specpass", IsBusy = RandomBool(),    AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",    JoinedOn = RandomDateTime() },
                new Specialist { Username = "Michal" ,  Password = "specpass", IsBusy = RandomBool(),    AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",    JoinedOn = RandomDateTime() },
                new Specialist { Username = "Pawel" ,   Password = "specpass", IsBusy = RandomBool(),    AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",      JoinedOn = RandomDateTime() },
                new Specialist { Username = "Grzegorz", Password = "specpass", IsBusy = RandomBool(),    AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",  JoinedOn = RandomDateTime() },
                new Specialist { Username = "Michal" ,  Password = "specpass", IsBusy = RandomBool(),    AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",    JoinedOn = RandomDateTime() },
                new Specialist { Username = "Jan" ,     Password = "specpass", IsBusy = RandomBool(),    AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",        JoinedOn = RandomDateTime() },
                new Specialist { Username = "Jozef" ,   Password = "specpass", IsBusy = RandomBool(),    AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",     JoinedOn = RandomDateTime() },
                new Specialist { Username = "Marek" ,   Password = "specpass", IsBusy = RandomBool(),    AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",     JoinedOn = RandomDateTime() },
                new Specialist { Username = "Bogdan" ,  Password = "specpass", IsBusy = RandomBool(),    AccountRole = AccountRole.Specialist, CraftAreaName = "motorcycle workshop/repair",     JoinedOn = RandomDateTime() },
            };
            foreach (var specialist in specialists)
                context.Account.Add(specialist);
        }

        private static void SeedAssignments(EfDbContext context)
        {
            var assignments = new Assignment[]
            {
                new Assignment
                {
                    AddedOn = RandomDateTime(),
                    AssignmentStatus = AssignmentStatus.Awaiting,
                    AssignorID = 1,
                    SpecialistID = 5,
                    ResultDescription = "machine ready for long journey (fixes, repairs and standard checks)",
                    ExpiresOn = RandomDateTime(),
                    ProposedDoneOn = RandomDateTime(),
                    ProposedMaxPrice = 1200,
                },
                new Assignment
                {
                    AddedOn = RandomDateTime(),
                    AssignmentStatus = AssignmentStatus.Done,
                    AssignorID = 1,
                    SpecialistID = 5,
                    ResultDescription = "bring back engine to life",
                    ExpiresOn = RandomDateTime(),
                    ProposedDoneOn = RandomDateTime(),
                    ProposedMaxPrice = 2200,
                },
                new Assignment
                {
                    AddedOn = RandomDateTime(),
                    AssignmentStatus = AssignmentStatus.Done,
                    AssignorID = 1,
                    SpecialistID = 5,
                    ResultDescription = "just routine chackes",
                    ExpiresOn = RandomDateTime(),
                    ProposedDoneOn = RandomDateTime(),
                    ProposedMaxPrice = 200,
                }
            };
            foreach (var assignment in assignments)
                context.Assignment.Add(assignment);
        }

        private static DateTime RandomDateTime()
        {
            _range = (DateTime.Today - _startDate).Days;
            return _startDate.AddDays(_random.Next(_range)).AddSeconds(_random.Next(_range));
        }

        private static bool RandomBool()
        {
            return _random.NextDouble() > 0.5;
        }
    }
}