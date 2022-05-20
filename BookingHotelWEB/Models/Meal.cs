using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingHotelWEB.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Add The Meal Type filed")]
        [DataType(DataType.Text)]
        public string MealType { get; set; }


    }
}
