using System.ComponentModel.DataAnnotations;
using BadmintonCourts.Models;

namespace BadmintonRentals.Models
{
    public class Location
    {
        [Key]
        public int LocationsID { get; set; }

        [Required, MinLength(2), MaxLength(50), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Location Name must only contain letters, numbers or spaces.")]
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Address must only contain letters, numbers or spaces.")]
        [Display(Name = "Address")]
        public string Addresss { get; set; }

        [Required, MinLength(2), MaxLength(50), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Suburb must only contain letters, numbers or spaces.")]
        [Display(Name = "Suburb")]
        public string Suburb { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "City must only contain letters, numbers or spaces.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Postal code must only contain letters, numbers or spaces.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required, RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Invalid phone number format (please include +64)")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public ICollection<Court> Courts { get; set; }

    }
}
