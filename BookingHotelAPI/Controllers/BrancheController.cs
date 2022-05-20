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
    public class BrancheController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _context;
        private UnitOfWork _unitOfWork;
        public BrancheController(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var GetBranch = _unitOfWork.BrancheRepository.Get();
            return Ok(GetBranch);

        }
        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            var GetBooking = _unitOfWork.BrancheRepository.GetById(id);
            if (GetBooking == null)
            {
                return NotFound();
            }
            return Ok(GetBooking);

        }
        [HttpPost("")]
        public IActionResult Create([FromBody] BrancheVM bra)
        {
            var branch = _mapper.Map<Branche>(bra);

            if (branch == null)
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.BrancheRepository.Add(branch);
                _unitOfWork.Save();
                return Ok();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] BrancheVM branche)
        {
            var bran = _mapper.Map<Branche>(branche);
            if (ModelState.IsValid)
            {
                _unitOfWork.BrancheRepository.Edit(id, bran);
                _unitOfWork.Save();
                return Ok();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _unitOfWork.BrancheRepository.Delete(id);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
