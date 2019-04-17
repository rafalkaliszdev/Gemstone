using System;
using System.Collections.Generic;
using System.Text;

namespace Gemstone.Core.Domain
{
    /// <summary>
    /// Represents a person or company which can add Assignment and Review
    /// </summary>
    public class Assignor
    {
        IList<Assignment> CreatedAssignments { get; set; }
        IList<Review> WrittenReviews { get; set; }
        DateTime JoinedOn { get; set; }
        public object GeoCoordinate { get; set; }
    }
}