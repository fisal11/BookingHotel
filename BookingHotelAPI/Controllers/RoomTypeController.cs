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
    public class RoomTypeController : ControllerBase
    {

        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _context;
        private UnitOfWork _unitOfWork;
        public RoomTypeController(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var GetAllRoomeTypes = _unitOfWork.RoomTypeRepository.Get();
            return Ok(GetAllRoomeTypes);

        }

        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            var GetBooking = _unitOfWork.RoomTypeRepository.GetById(id);
            if (GetBooking == null)
            {
                return NotFound();
            }
            return Ok(GetBooking);

        }
        [HttpPost(" ")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] RoomTypeVM roomType)
        {
            var RoomeTypes = _mapper.Map<RoomType>(roomType);
            if (RoomeTypes == null)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.RoomTypeRepository.Add(RoomeTypes);
                _unitOfWork.Save();
                return Ok();
            }
            return Ok(roomType);
        }
       
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, [FromBody] RoomTypeVM roomType)
        {
            var RoomeTypes = _mapper.Map<RoomType>(roomType);

            if (RoomeTypes == null || id != RoomeTypes.Id)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.RoomTypeRepository.Edit(id, RoomeTypes);
                _unitOfWork.Save();
                return Ok();
            }
            return Ok(roomType);

        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, RoomTypeVM roomType)
        {
            if (roomType == null || id != roomType.Id)
            {
                return BadRequest(ModelState);
            }
            _unitOfWork.RoomTypeRepository.GetById(id);
            _unitOfWork.RoomTypeRepository.Delete(id);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
