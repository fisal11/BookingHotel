using BookingHotelAPI.Model;
using BookingHotelAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;

        public AccountController(IAccount accountRepo)
        {
            _account = accountRepo;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signUpModel)
        {
            var result = await _account.SignUp(signUpModel);

            if (result.Succeeded)
            {

                return Ok(result.Succeeded);
            }
            return Unauthorized();

        }
        [HttpPost("signin")]
        public async Task<IActionResult> signin([FromBody] SignIn signInModel)
        {
            var result = await _account.SignIn(signInModel);

            if (string.IsNullOrEmpty(result))
            {

                return Unauthorized();
            }
            return Ok(result);

        }
    }
}
