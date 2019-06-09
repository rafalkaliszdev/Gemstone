using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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