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
        public int TakenAssignmentsCount { get; set; }
        public int ReceivedReviewsCount { get; set; }
        public DateTime JoinedOn { get; set; }
    }
}
