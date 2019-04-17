using System;
using System.Collections.Generic;
using System.Text;

namespace Gemstone.Core.Domain
{
    /// <summary>
    /// Represents a Professional or Team of Professionals which can receive and get done Assignment 
    /// </summary>
    public class Professional
    {
        public Queue<Assignment> TakenAssignments { get; set; }
        public IList<Review> ReceivedReviews { get; set; }
        public DateTime JoinedOn { get; set; }
        public object GeoCoordinate { get; set; }
    }
}