using System.ComponentModel.DataAnnotations;

namespace ef_core_haymatlos.DTOs
{
    public class UserModelDTO
    {
        [Required(ErrorMessage = "Nickname is required.")]
        public string? Nickname { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
