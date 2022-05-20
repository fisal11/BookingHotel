using Microsoft.AspNetCore.Identity;


namespace BookingHotelAPI.DAL.Entitis
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
