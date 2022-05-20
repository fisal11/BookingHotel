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
    public class BookingController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _context;
        private UnitOfWork _unitOfWork;
        public BookingController(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var GetBooking = _unitOfWork.BookingRepository.Get();
            return Ok(GetBooking);

        }
        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            var GetBooking = _unitOfWork.BookingRepository.GetById(id);
            if (GetBooking == null)
            {
                return NotFound();
            }
            return Ok(GetBooking);

        }
        [HttpPost("")]
        public IActionResult Create([FromBody] BookingVM booking)
        {
            var Booking = _mapper.Map<Booking>(booking);

            if (Booking == null)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.BookingRepository.Add(Booking);
                _unitOfWork.Save();
                return Ok();
            }
            return Ok(booking);
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] BookingVM booking)
        {
            var Booking = _mapper.Map<Booking>(booking);
            if (Booking == null || id != booking.Id)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.BookingRepository.Edit(id, Booking);
                _unitOfWork.Save();
                return Ok();
            }
            return Ok(booking);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id, BookingVM booking)
        {
            if (booking == null || id != booking.Id)
            {
                return BadRequest(ModelState);
            }
            _unitOfWork.BookingRepository.GetById(id);
            _unitOfWork.BookingRepository.Delete(id);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
