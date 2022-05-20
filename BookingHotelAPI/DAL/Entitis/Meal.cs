using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelAPI.DAL.Entitis
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Add The Meal Type filed")]
        [DataType(DataType.Text)]
        public string MealType { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }


    }
}
