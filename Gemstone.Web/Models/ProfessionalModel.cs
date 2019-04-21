using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Web.Models
{
    public class ProfessionalModel
    {
        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public IList<string> TakenAssignments { get; set; }
        public IList<string> ReceivedReviews { get; set; }
        public DateTime JoinedOn { get; set; }
        public string GeoCoordinate { get; set; }
    }
}
