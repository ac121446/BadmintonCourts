using System.ComponentModel.DataAnnotations;
using BadmintonCourts.Models;

namespace BadmintonRentals.Models
{
    public class Payment
    {
        [Key]
        public int LocationID { get; set; }

        [Required(ErrorMessage = "Enter location name")]
        public string LocationName { get; set; }

        [Required(ErrorMessage = "Enter the address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter the suburb")]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "Enter the city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter the postal code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Enter the phone number")]
        public string PhoneNumber { get; set; }


        public Booking Booking { get; set; }
    }
}
