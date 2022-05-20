using AutoMapper;
using BookingHotelAPI.DAL.Context;
using BookingHotelAPI.DAL.Entitis;
using BookingHotelAPI.Model;
using BookingHotelAPI.Repository.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MealController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _context;
        private UnitOfWork _unitOfWork;
        public MealController(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var GetAllMeals = _unitOfWork.MealsRepository.Get();
            return Ok(GetAllMeals);

        }
        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            var GetBooking = _unitOfWork.MealsRepository.GetById(id);
            if (GetBooking == null)
            {
                return NotFound();
            }
            return Ok(GetBooking);

        }
        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] MealVM meal)
        {
            var Meal = _mapper.Map<Meal>(meal);
            if (Meal == null)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.MealsRepository.Add(Meal);
                _unitOfWork.Save();
                return Ok();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, [FromBody] MealVM meal)
        {
            var Meal = _mapper.Map<Meal>(meal);
            if (Meal == null || id != Meal.Id)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.MealsRepository.Edit(id, Meal);
                _unitOfWork.Save();
                return Ok();
            }
            return Ok(meal);

        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, MealVM meals)
        {
            if (meals == null || id != meals.Id)
            {
                return BadRequest(ModelState);
            }
            _unitOfWork.MealsRepository.GetById(id);
            _unitOfWork.MealsRepository.Delete(id);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
