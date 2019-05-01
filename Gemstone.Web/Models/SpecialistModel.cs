using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Web.Models
{
    public class SpecialistModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public DateTime JoinedOn { get; set; }
    }
}
