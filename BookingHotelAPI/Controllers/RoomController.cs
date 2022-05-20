using AutoMapper;
using BookingHotelAPI.DAL.Context;
using BookingHotelAPI.DAL.Entitis;
using BookingHotelAPI.Model;
using BookingHotelAPI.Helper;
using BookingHotelAPI.Repository.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookingHotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoomController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _context;
        private UnitOfWork _unitOfWork;
        public RoomController(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var GetRooms = _unitOfWork.RoomRepository.Get();
            return Ok(GetRooms);

        }
        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            var GetBooking = _unitOfWork.RoomRepository.GetById(id);
            if (GetBooking == null)
            {
                return NotFound();
            }
            return Ok(GetBooking);

        }
        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] RoomVM room)
        {
            var Rooms = _mapper.Map<Room>(room);
            if (Rooms == null)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                Rooms.Image = UploadFile.SavaFile(room.PhotoUrl, "Photos");
                _unitOfWork.RoomRepository.Add(Rooms);
                _unitOfWork.Save();
                return Ok();
            }
            return Ok(room);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, [FromBody] RoomVM room)
        {
            var Rooms = _mapper.Map<Room>(room);

            if (Rooms == null || id != Rooms.Id)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                Rooms.Image = UploadFile.SavaFile(room.PhotoUrl, "Photos");
                _unitOfWork.RoomRepository.Edit(id, Rooms);
                _unitOfWork.Save();
                return Ok();
            }
            return Ok(room);

        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, RoomVM room)
        {
            var data = _mapper.Map<Room>(room);
            if (room == null || id != room.Id)
            {
                return BadRequest(ModelState);
            }
            UploadFile.DeleteFile("Photos/", data.Image);
            _unitOfWork.RoomRepository.GetById(id);
            _unitOfWork.RoomRepository.Delete(id);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
