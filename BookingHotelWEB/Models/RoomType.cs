using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingHotelWEB.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Add The Room of Type filed")]
        [DataType(DataType.Text)]
        public string Roomtype { get; set; }
    }
}
