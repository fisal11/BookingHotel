using System.ComponentModel.DataAnnotations;

namespace BookingHotelAPI.Model
{
    public class SignUp
    {
        [Key]

        [Required(ErrorMessage = "Please Enter Your First Name ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Last Name ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email ")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password ")]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Your ConfirmPassword ")]
        public string ConfirmPassword { get; set; }
    }
}
