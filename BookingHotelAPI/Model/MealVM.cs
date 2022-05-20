using System.ComponentModel.DataAnnotations;

namespace BookingHotelAPI.Model
{
    public class MealVM
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Add The Meal Type filed")]
        [DataType(DataType.Text)]
        public string MealType { get; set; }



    }
}
