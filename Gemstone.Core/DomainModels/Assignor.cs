using System;
using System.Collections.Generic;
using System.Text;
using Gemstone.Core.Abstracts;

namespace Gemstone.Core.DomainModels
{
    /// <summary>
    /// Represents a Assignor web app user
    /// </summary>
    public class Assignor : Account
    {
        public string SomeFieldDescribingAssingor { get; set; }
    }
}