﻿using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.Abstracts;

namespace Gemstone.Core.Domain
{
    /// <summary>
    /// Represents a person or company which can add Assignment and Review
    /// </summary>
    public class Assignor : BaseEntity
    {
        IList<Assignment> CreatedAssignments { get; set; }
        IList<Review> WrittenReviews { get; set; }
        DateTime JoinedOn { get; set; }
    }
}