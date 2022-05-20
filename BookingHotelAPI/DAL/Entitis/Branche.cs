using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotelAPI.DAL.Entitis
{
    public class Branche
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Add The PrancheName filed")]
        [DataType(DataType.Text)]
        public string PrancheName { get; set; }

        public virtual ICollection<RoomType> RoomTypes { get; set; }

    }
}
