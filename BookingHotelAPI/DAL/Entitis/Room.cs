using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelAPI.DAL.Entitis
{
    public class Room
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
        public virtual RoomType RoomType { get; set; }



    }
}
