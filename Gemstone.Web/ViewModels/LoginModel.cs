using Gemstone.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Web.ViewModels
{
    public class LoginModel
    {
        [Required]
        [DisplayName("User name")]
        [MinLength(2, ErrorMessage = "Minimum length 2 characters")]
        [MaxLength(10, ErrorMessage = "Max length 10 characters")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}