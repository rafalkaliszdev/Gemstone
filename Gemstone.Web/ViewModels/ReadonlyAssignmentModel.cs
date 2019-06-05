using Gemstone.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Web.ViewModels
{
    public class ReadonlyAssignmentModel : DirectAssignmentModel
    {
        [DisplayName("Added On")]
        public DateTime AddedOn { get; set; }
        [DisplayName("Assignment Status")]
        public AssignmentStatus AssignmentStatus { get; set; }
        [DisplayName("Assignor Name")]
        public string AssignorName { get; set; }
    }
}