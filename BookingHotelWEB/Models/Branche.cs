using System.ComponentModel.DataAnnotations;

namespace BookingHotelWEB.Models
{
    public class Branche
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Add The PrancheName filed")]
        [DataType(DataType.Text)]
        public string PrancheName { get; set; }

    }
}