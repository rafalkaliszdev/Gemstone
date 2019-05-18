using Gemstone.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Web.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username field is required")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Username should be between 2 and 10 characters")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name ="Select role")]
        public string SelectedRoleName { get; set; }
        public SelectList AvailableRoles { get; set; }
    }
}