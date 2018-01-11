using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaBookingWeb.Models
{
    public class User
    {
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 2)]
        public string UserName { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public bool IsValid(string username, string password)
        {
            //here implement some logic
            return username == "admin" && password == "admin";
        }
    }
}