using System.ComponentModel.DataAnnotations;
using BadmintonCourts.Models;

namespace BadmintonRentals.Models
{
    public class Equipment
    {
        [Key]
        public string EquipmentsID { get; set; }

        [Required(ErrorMessage = "Enter the name of your equipment")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the type of equipment")]
        public string Type { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
