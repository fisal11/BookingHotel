using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelAPI.DAL.Entitis
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Add The Room of Type filed")]
        [DataType(DataType.Text)]
        public string Roomtype { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }


    }
}
