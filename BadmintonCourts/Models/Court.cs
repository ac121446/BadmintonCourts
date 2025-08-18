using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BadmintonCourts.Models;

namespace BadmintonCourts.Models
{
    public class Court
    {
        [Key]
        public int CourtID { get; set; }

        [ForeignKey("LocationID"), Required]
        public int LocationID { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Court name must only contain letters, numbers or spaces.")]
        [Display(Name = "Court Name")]
        public string CourtName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
        public Location? Location { get; set; }

    }
}
