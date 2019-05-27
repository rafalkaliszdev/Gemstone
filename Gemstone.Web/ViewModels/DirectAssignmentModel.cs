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
        [DisplayName("Proposed max price")]
        public decimal ProposedMaxPrice { get; set; }
        [Required]
        [DisplayName("Proposed done on")]
        public DateTime ProposedDoneOn { get; set; }
        [Required]
        [DisplayName("Expires on")]
        public DateTime ExpiresOn { get; set; }
        [Required]
        [DisplayName("Result description")]
        public string ResultDescription { get; set; }
    }
}