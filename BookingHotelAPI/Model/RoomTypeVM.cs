using System.ComponentModel.DataAnnotations;

namespace BookingHotelAPI.Model
{
    public class RoomTypeVM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Add The Room of Type filed")]
        [DataType(DataType.Text)]
        public string Roomtype { get; set; }

    }
}
