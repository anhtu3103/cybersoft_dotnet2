using System.ComponentModel.DataAnnotations;

public class ContactModel
{
    [Required(ErrorMessage = "FullName is required.")]
    public string FullName { get; set; }  = string.Empty;

    [Required(ErrorMessage = "Please enter your email")]
    [EmailAddress(ErrorMessage = "Please enter a valid email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter your phone number")]
    [RegularExpression(@"^\d{10,12}$", ErrorMessage = "Please enter a valid phone number")]
    public string PhoneNumbers { get; set; }
}