using Gemstone.Core.Abstracts;
using Gemstone.Core.Enums;
using System;
using System.Collections.Generic;

namespace Gemstone.Core.DomainModels
{
    /// <summary>
    /// Represents a web app user (Specialist or Assignor)
    /// </summary>
    public abstract class Account : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AccountRole AccountRole { get; set; }
        public DateTime JoinedOn { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}