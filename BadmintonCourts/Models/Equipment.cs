using System.ComponentModel.DataAnnotations;
using BadmintonCourts.Models;

namespace BadmintonRentals.Models
{
    public class Equipment
    {
        [Key]
        public string EquipmentID { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Equipment name must only contain letters, numbers or spaces.")]
        [Display(Name = "Equipment Name")]
        public string Name { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Equipment type must only contain letters, numbers or spaces.")]
        [Display(Name = "Equipment Type")]
        public string Type { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
