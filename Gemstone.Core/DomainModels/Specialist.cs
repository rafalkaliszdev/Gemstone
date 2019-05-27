using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.Abstracts;

namespace Gemstone.Core.DomainModels
{
    /// <summary>
    /// Represents a Specialist web app user
    /// </summary>
    public class Specialist : Account
    {
        public string CraftAreaName { get; set; }
        public bool IsBusy { get; set; }

        // navigation properties
        public ICollection<Assignment> Assignments { get; set; }
    }
}