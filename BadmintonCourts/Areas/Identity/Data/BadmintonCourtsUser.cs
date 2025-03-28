using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BadmintonCourts.Models;
using Microsoft.AspNetCore.Identity;

namespace BadmintonCourts.Areas.Identity.Data;

// Add profile data for application users by adding properties to the BadmintonCourtsUser class
public class BadmintonCourtsUser : IdentityUser
{
    [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must only contain letters, no special characters or spaces.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
  
    [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must only contain letters, no special characters or spaces.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    //User Phone Number field with validation rules, an error message will display if the regular expression (standard NZ phone number) format is not met.
    [Required, RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Invalid phone number format (please include +64)")]
    public string PhoneNumber { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}


