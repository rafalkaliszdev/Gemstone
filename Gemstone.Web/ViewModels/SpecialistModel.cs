﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gemstone.Web.ViewModels
{
    public class SpecialistModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public bool IsBusy { get; set; }
        public string CraftAreaName { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime JoinedOn { get; set; }

        public ICollection<ReadonlyAssignmentModel> Assignments { get; set; }
    }
}
