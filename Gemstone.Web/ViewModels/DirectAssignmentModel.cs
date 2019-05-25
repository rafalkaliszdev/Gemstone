using System;
using System.ComponentModel.DataAnnotations;

namespace Gemstone.Web.ViewModels
{
    public class DirectAssignmentModel
    {
        public long SpecialistID { get; set; }
        public string SpecialistName { get; set; }

        [Required]
        public decimal MaxAcceptablePrice { get; set; }
        [Required]
        public DateTime ValidUntil { get; set; }
        [Required]
        public string ExpectedResult { get; set; }
        [Required]
        public DateTime ExpectedDoneOn { get; set; }
    }
}