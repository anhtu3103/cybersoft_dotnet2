using System.ComponentModel.DataAnnotations;

namespace session40_50.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "User";
    }
}
