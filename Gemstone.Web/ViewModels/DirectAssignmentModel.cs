using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gemstone.Web.ViewModels
{
    public class DirectAssignmentModel
    {
        public long AssignorID { get; set; }
        public long SpecialistID { get; set; }
        public string SpecialistName { get; set; }

        [Required]
        [DisplayName("Proposed Max Price")]
        public decimal ProposedMaxPrice { get; set; }
        [Required]
        [DisplayName("Proposed Done On")]
        public DateTime ProposedDoneOn { get; set; }
        [Required]
        [DisplayName("Expires On")]
        public DateTime ExpiresOn { get; set; }
        [Required]
        [DisplayName("Result Description")]
        public string ResultDescription { get; set; }
    }
}