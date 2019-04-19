using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.Domain;
using Gemstone.Core.Enums;

namespace Gemstone.Core.Services
{
    public class ProfessionalService : IProfessionalService
    {
        public IList<Professional> GetAllProfessionals()
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

            return new List<Professional>()
            {
                new Professional
                {
                    Name = "Michal",
                    IsBusy = true,
                    GeoCoordinate = "jeden",
                    JoinedOn = new DateTime(2019,4,19),
                    ReceivedReviews = new List<Review>() { exampleReview },
                    TakenAssignments = new List<Assignment>() { exampleAssignment }
                },
                new Professional
                {
                    Name = "Marcin",
                    IsBusy = false,
                    GeoCoordinate = "dwa",
                    JoinedOn = new DateTime(2019,4,19),
                    ReceivedReviews = new List<Review>() { exampleReview },
                    TakenAssignments = new List<Assignment>() { exampleAssignment }
                },
                new Professional
                {
                    Name = "Pawel",
                    IsBusy = false,
                    GeoCoordinate = "trzy",
                    JoinedOn = new DateTime(2019,4,19),
                    ReceivedReviews = new List<Review>() { exampleReview },
                    TakenAssignments = new List<Assignment>() { exampleAssignment }
                },
            };
        }
    }
}
