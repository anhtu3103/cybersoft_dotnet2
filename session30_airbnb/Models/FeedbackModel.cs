using System.ComponentModel.DataAnnotations;

namespace session30_airbnb.Models
{
    public class FeedbackModel
    {
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }
        [Required]
        public double Cleaniness { get; set; } = 5;
        public double Staff { get; set; } = 5;
        public double Comfort { get; set; } = 5;
        public double Value { get; set; } = 5;
    }
}
