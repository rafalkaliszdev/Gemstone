using Gemstone.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gemstone.Core.Domain
{
    /// <summary>
    /// Represents a task/order that can be created by Assignor, taken and executed by Professional
    /// </summary>
    public class Assignment
    {
        decimal MaxAcceptablePrice { get; set; }
        DateTime AddedOn { get; set; }
        DateTime ValidUntil { get; set; }
        AssignmentStatus AssignmentStatus { get; set; }
        string ExpectedResult { get; set; }
        DateTime ExpectedDoneOn { get; set; }
        Review Review { get; set; }
    }
}