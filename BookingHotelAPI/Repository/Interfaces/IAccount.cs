using BookingHotelAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace BookingHotelAPI.Repository.Interfaces
{
    public interface IAccount
    {
        Task<IdentityResult> SignUp(SignUp signUpModel);
        Task<string> SignIn(SignIn signInModel);
    }
}
