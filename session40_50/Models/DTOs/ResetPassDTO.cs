using System.ComponentModel.DataAnnotations;

namespace session40_50.Models.DTOs
{
    public class ResetPassDTO
    {
        [Required(ErrorMessage = "Please enter token to reset password")]
        public string ResetToken { get; set; }

        [Required(ErrorMessage = "Must be enter new password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Must be enter confirm new password")]
        public string ConfirmNewPassword { get; set; }

    }
}
