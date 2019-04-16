using System;
using System.Collections.Generic;
using System.Text;

namespace Gemstone.Core.Domain
{
    public class Professional
    {
        public Queue<Assignment> Assignments { get; set; }
        public IList<Review> Reviews { get; set; }
        public DateTime JoinedOn { get; set; }
        public object GeoCoordinate { get; set; }
    }
}