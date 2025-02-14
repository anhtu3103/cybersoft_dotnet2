using System.ComponentModel.DataAnnotations;

public class UserModel {
    
    [Required(ErrorMessage = "Please input username")]
    [MinLength(6, ErrorMessage = "Username must be at least 8 characters")]
    [MaxLength(20, ErrorMessage = "Username must be at most 20 characters")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "please input password")]
    [MinLength(8, ErrorMessage = "Passwords must be at least 8 characters")]
    public string Passwords { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Gender { get; set; } = "Male";

    public string Country { get; set; } = "Vietnam";

    [Required(ErrorMessage = "Please input phone number")]
    [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Phone nuumber must be 10-12 digits")]
    public string Phone { get; set; }  = string.Empty;
}