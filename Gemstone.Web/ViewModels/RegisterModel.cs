using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Gemstone.Web.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username field is required")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Username should be between 2 and 10 characters")]
        [Remote("CheckUsernameNotTaken", "Account", ErrorMessage = "Username already taken")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name ="Select role")]
        public string SelectedRoleName { get; set; }
        public SelectList AvailableRoles { get; set; }
    }
}