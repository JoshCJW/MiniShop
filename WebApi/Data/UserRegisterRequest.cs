using System.ComponentModel.DataAnnotations;

namespace WebApi.Data
{
    public class UserRegisterRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Required, Compare("Password")]
        public string ConfirmPassoword { get; set; } = string.Empty;
    }
}
