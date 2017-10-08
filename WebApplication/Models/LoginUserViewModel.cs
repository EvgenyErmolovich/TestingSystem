using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication.Models.User
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "login")]
        [Remote("ValidLogUp", "Account", ErrorMessage = "This login is not registered in our system.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string Password { get; set; }

        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }
    }
}