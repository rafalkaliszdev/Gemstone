using Gemstone.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.Abstracts;

namespace Gemstone.Core.Domain
{
    /// <summary>
    /// Represents a task/order that can be created by Assignor, taken and executed by Professional
    /// </summary>
    public class Assignment : BaseEntity
    {
        public decimal MaxAcceptablePrice { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ValidUntil { get; set; }
        public AssignmentStatus AssignmentStatus { get; set; }
        public string ExpectedResult { get; set; }
        public DateTime ExpectedDoneOn { get; set; }
        public Review Review { get; set; }
    }
}