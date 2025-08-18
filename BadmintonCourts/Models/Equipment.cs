using System.ComponentModel.DataAnnotations;
using BadmintonCourts.Models;

namespace BadmintonCourts.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentID { get; set; }

        [Required, MinLength(2), MaxLength(50), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Equipment name must only contain letters, numbers or spaces.")]
        [Display(Name = "Equipment Name")]
        public string EName { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Equipment type must only contain letters, numbers or spaces.")]
        [Display(Name = "Equipment Type")]
        public string EType { get; set; }

        [Required]
        public decimal EPrice { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
