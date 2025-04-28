using System.ComponentModel.DataAnnotations;

namespace session40_50.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public String Email { get; set; }
        public string Password { get; set; }
        public bool IsEmailVerified { get; set; } = false;
        public string? VerificationToken { get; set; }
        public DateTime? CreateAt { get; set; }  = DateTime.UtcNow;
        public string Role { get; set; } = "User";
        public string TokenResetPassword { get; set; } = string.Empty;
        public DateTime ExpiresTokenReset { get; set; }
    }
}
