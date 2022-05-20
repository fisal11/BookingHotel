using System.ComponentModel.DataAnnotations;

namespace BookingHotelAPI.Model
{
    public class BrancheVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Add The PrancheName filed")]
        [DataType(DataType.Text)]
        public string PrancheName { get; set; }


    }
}
