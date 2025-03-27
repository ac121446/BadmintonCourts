using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BadmintonCourts.Models;

namespace BadmintonRentals.Models
{
    public class Court
    {
        [Key]
        public int CourtID { get; set; }

        [ForeignKey("LocationID"), Required]
        public int LocationID { get; set; }

        [Required(ErrorMessage = "Enter the name")]
        public string CourtName { get; set; }

        [Required(ErrorMessage = "Enter the court type")]
        public string CourtType { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public Location Location { get; set; }

    }
}
