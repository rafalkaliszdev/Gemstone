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
        public string Name { get; set; }

        public bool IsBusy { get; set; }

        // as well, what queue is for? does it even make sense for domain ?
        public /*Queue*/IList<Assignment> TakenAssignments { get; set; }
        public IList<Review> ReceivedReviews { get; set; }
        public DateTime JoinedOn { get; set; }
        public /*object*/string GeoCoordinate { get; set; }
    }
}