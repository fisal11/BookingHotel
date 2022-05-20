using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelAPI.DAL.Entitis
{
    public class Booking
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name ")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Enter Your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Your Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Please Select CheckIn Date")]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Please Select CheckOut Date")]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        public int NumberOfRooms { get; set; }


        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }


        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }


    }
}
