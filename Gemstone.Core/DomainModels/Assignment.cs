using Gemstone.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.Abstracts;
using Gemstone.Core.DomainModels;

namespace Gemstone.Core.DomainModels
{
    /// <summary>
    /// Represents a task/order that can be created by Assignor, taken and executed by Specialist
    /// </summary>
    public class Assignment : EntityBase
    {
        public long notAssignorID { get; set; }
        public long notSpecialistID { get; set; }

        public decimal ProposedMaxPrice { get; set; }
        public DateTime ProposedDoneOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string ResultDescription { get; set; }
        public DateTime AddedOn { get; set; }

        public AssignmentStatus AssignmentStatus { get; set; }

        public Assignor Assignor { get; set; }
        public Specialist Specialist { get; set; }

        //public Review Review { get; set; }
    }
}