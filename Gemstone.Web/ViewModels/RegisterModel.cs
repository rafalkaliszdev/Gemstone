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
        // todo test this attribute
        [Required(ErrorMessage = "Username field is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Invalid")]
        public string Username { get; set; }

        [Required]
        // todo test this attributes
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string SelectedRole { get; set; }

        public AccountRole AccountRole { get; set; }
        public SelectList AvailableRoles { get; set; }
    }
}