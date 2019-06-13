using Gemstone.Core.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gemstone.Web.ViewModels
{
    public class ReadonlyAssignmentModel : DirectAssignmentModel
    {
        [DisplayName("Added On")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime AddedOn { get; set; }

        [DisplayName("Assignment Status")]
        public AssignmentStatus AssignmentStatus { get; set; }

        [DisplayName("Assignor Name")]
        public string AssignorName { get; set; }
    }
}