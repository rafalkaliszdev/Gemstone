using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.Abstracts;

namespace Gemstone.Core.Domain
{
    /// <summary>
    /// Represents a Specialist or Team of Specialists which can receive and get done Assignment 
    /// </summary>
    public class Specialist : EntityBase
    {
        public string Name { get; set; }
        public bool IsBusy { get; set; }
        //public IList<Assignment> TakenAssignments { get; set; }
        //public IList<Review> ReceivedReviews { get; set; }
        public DateTime JoinedOn { get; set; }
    }
}