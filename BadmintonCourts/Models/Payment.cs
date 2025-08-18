using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BadmintonCourts.Models;

namespace BadmintonCourts.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [ForeignKey("BookingID"), Required]
        public int BookingID { get; set; }

        [Required]
        public decimal PaymentAmount { get; set; }

        [Required(ErrorMessage = "Enter your booking date")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentStatus { get; set; }

        public Booking? Booking { get; set; }
    }
}
