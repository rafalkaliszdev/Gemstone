using Gemstone.Core.Abstracts;
using Gemstone.Core.Enums;
using System;

namespace Gemstone.Core.DomainModels
{
    /// <summary>
    /// Represents a task/order that can be created by Assignor, taken and executed by Specialist
    /// </summary>
    public class Assignment : EntityBase
    {
        public string WorkResultDescription { get; set; }
        public decimal ProposedMaxPrice { get; set; }
        public DateTime ProposedDoneOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public DateTime AddedOn { get; set; }

        public AssignmentStatus AssignmentStatus { get; set; }

        public long AssignorID { get; set; }
        public Assignor Assignor { get; set; }

        public long SpecialistID { get; set; }
        public Specialist Specialist { get; set; }

        //public Review Review { get; set; }
    }
}