using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Web.ViewModels
{
    public class SpecialistModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public DateTime JoinedOn { get; set; }
    }
}
