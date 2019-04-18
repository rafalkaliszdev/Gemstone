using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Web.Models
{
    public class ProfessionalModel
    {
        public Queue</*Assignment*/string> TakenAssignments { get; set; }
        public IList</*Review*/string> ReceivedReviews { get; set; }
        public DateTime JoinedOn { get; set; }
        public string GeoCoordinate { get; set; }
    }
}
