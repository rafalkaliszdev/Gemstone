using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.Domain;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Enums;
using Gemstone.Core.Interfaces;

namespace Gemstone.Core.Services
{
    // todo very much to do here
    public class SpecialistService : ISpecialistService
    {
        public Account GetById(string id)
        {
            return new Account
            {
                Name = "Michal",
                IsBusy = true,
                JoinedOn = new DateTime(2019, 4, 19),
            };
        }

        public IList<Account> GetAll()
        {
            //var exampleAssignment = new Assignment
            //{
            //    AddedOn = new DateTime(2019, 4, 9),
            //    AssignmentStatus = AssignmentStatus.Done,
            //    ExpectedDoneOn = new DateTime(2019, 4, 15),
            //    ValidUntil = new DateTime(2019, 4, 9),
            //    ExpectedResult = "prepare moto for long journey",
            //    MaxAcceptablePrice = 12.34M,
            //};
            //var exampleReview = new Review
            //{
            //    Assignment = exampleAssignment,
            //    AddedOn = new DateTime(2019, 4, 9),
            //    AdditionalRemarks = "moto prepared as expected",
            //    CommunicationQuality = CommunicationQuality.OftenAndDetailed,
            //    RealizationQuality = RealizationQuality.ConditionsMet,
            //    RealizationTime = RealizationTime.BeforeDeadline
            //};

            var data = new List<Account>()
            {
                new Account
                {
                    Name = "Michal",
                    IsBusy = true,
                    JoinedOn = new DateTime(2019,4,19),

                },
                new Account
                {
                    Name = "Marcin",
                    IsBusy = false,
                    JoinedOn = new DateTime(2019,4,19),

                },
                new Account
                {
                    Name = "Pawel",
                    IsBusy = false,
                    JoinedOn = new DateTime(2019,4,19),

                },
            };

            var data2 = new List<Account>();
            data2.AddRange(data);
            data2.AddRange(data);
            data2.AddRange(data);
            data2.AddRange(data);
            data2.AddRange(data);
            return data2;

        }

        public void Create(Account Specialist)
        {
            throw new NotImplementedException();
        }

        public void Update(Account Specialist)
        {
            throw new NotImplementedException();
        }

        public void Delete(Account Specialist)
        {
            throw new NotImplementedException();
        }
    }
}
