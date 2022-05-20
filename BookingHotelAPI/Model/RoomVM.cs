using System.ComponentModel.DataAnnotations;

namespace BookingHotelAPI.Model
{
    public class RoomVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Add The Salary Per Night filed")]
        public decimal SalaryPerNight { get; set; }


        [Required(ErrorMessage = "Please Add The Image filed")]
        public string Image { get; set; }


        [Required(ErrorMessage = "Please Add The Size filed")]
        public double Size { get; set; }


        [Required(ErrorMessage = "Please Add The IsSingle filed")]
        public bool IsSingle { get; set; }


        [Required(ErrorMessage = "Please Add The Capacity filed")]
        public int Capacity { get; set; }


        public int RoomTypeId { get; set; }

        public IFormFile PhotoUrl { get; set; }
    }
}
