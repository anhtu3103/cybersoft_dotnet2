using System.ComponentModel.DataAnnotations;

namespace session30_airbnb.Models
{
    public class FeedbackModel
    {
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required]
        public double Cleaniness { get; set; } = 5;
    }
}
