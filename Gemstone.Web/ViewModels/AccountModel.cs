﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Web.ViewModels
{
    public class AccountModel
    {
        // todo add data annotations validation
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}