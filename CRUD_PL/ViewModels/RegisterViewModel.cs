using System.ComponentModel.DataAnnotations;

namespace CRUD_PL.ViewModels
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Confirm password doesn't match password")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }
    }
}
