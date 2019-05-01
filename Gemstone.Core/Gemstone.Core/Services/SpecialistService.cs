using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.Domain;
using Gemstone.Core.Enums;

namespace Gemstone.Core.Services
{
    public class SpecialistService : ISpecialistService
    {
        public Specialist GetById(string id)
        {
            return new Specialist
            {
                Name = "Michal",
                IsBusy = true,
                JoinedOn = new DateTime(2019, 4, 19),
                //ReceivedReviews = new List<Review>() { new Review { AdditionalRemarks = "moto prepared as expected" } },
                //TakenAssignments = new List<Assignment>() { new Assignment { ExpectedResult = "prepare moto for long journey" } }
            };
        }

        public IList<Specialist> GetAll()
        {
            var exampleAssignment = new Assignment
            {
                AddedOn = new DateTime(2019, 4, 9),
                AssignmentStatus = AssignmentStatus.Done,
                ExpectedDoneOn = new DateTime(2019, 4, 15),
                ValidUntil = new DateTime(2019, 4, 9),
                ExpectedResult = "prepare moto for long journey",
                MaxAcceptablePrice = 12.34M,
            };
            var exampleReview = new Review
            {
                Assignment = exampleAssignment,
                AddedOn = new DateTime(2019, 4, 9),
                AdditionalRemarks = "moto prepared as expected",
                CommunicationQuality = CommunicationQuality.OftenAndDetailed,
                RealizationQuality = RealizationQuality.ConditionsMet,
                RealizationTime = RealizationTime.BeforeDeadline
            };

            return new List<Specialist>()
            {
                new Specialist
                {
                    Name = "Michal",
                    IsBusy = true,
                    JoinedOn = new DateTime(2019,4,19),
                    //ReceivedReviews = new List<Review>() { exampleReview },
                    //TakenAssignments = new List<Assignment>() { exampleAssignment }
                },
                new Specialist
                {
                    Name = "Marcin",
                    IsBusy = false,
                    JoinedOn = new DateTime(2019,4,19),
                    //ReceivedReviews = new List<Review>() { exampleReview },
                    //TakenAssignments = new List<Assignment>() { exampleAssignment }
                },
                new Specialist
                {
                    Name = "Pawel",
                    IsBusy = false,
                    JoinedOn = new DateTime(2019,4,19),
                    //ReceivedReviews = new List<Review>() { exampleReview },
                    //TakenAssignments = new List<Assignment>() { exampleAssignment }
                },
            };
        }

        public void Create(Specialist Specialist)
        {
            throw new NotImplementedException();
        }

        public void Update(Specialist Specialist)
        {
            throw new NotImplementedException();
        }

        public void Delete(Specialist Specialist)
        {
            throw new NotImplementedException();
        }
    }
}
