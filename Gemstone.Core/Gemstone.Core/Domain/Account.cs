using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.Abstracts;

namespace Gemstone.Core.Domain
{
    /// <summary>
    /// Represents a web app user (Specialist or Assignor)
    /// </summary>
    public class Account : EntityBase
    {
        public string Name { get; set; }
        public bool IsBusy { get; set; }
        //public IList<Assignment> Assignments { get; set; }
        //public IList<Review> Reviews { get; set; }
        public DateTime JoinedOn { get; set; }
    }
}