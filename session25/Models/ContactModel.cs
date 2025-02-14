using System.ComponentModel.DataAnnotations;

public class ContactModel
{
    [Required(ErrorMessage = "Please input fullName")]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please input Email")]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please input phone")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please input address")]
    public string Address { get; set; } = string.Empty;

    [MinLength(5, ErrorMessage = "Message must be at least 5 character")]
    public string Message { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please input Services")]
    public string Services { get; set; } = string.Empty;

}