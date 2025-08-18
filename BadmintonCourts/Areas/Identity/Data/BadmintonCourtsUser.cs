using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BadmintonCourts.Models;
using Microsoft.AspNetCore.Identity;

namespace BadmintonCourts.Areas.Identity.Data;

public class BadmintonCourtsUser : IdentityUser
{
    //The field is required (cannot be empty).
    //The last name must have a minimum length of 2 characters and a maximum length of 20 characters.
    //The last name must match the regular expression, ensuring only alphabetic characters (no special characters or spaces) are allowed.
    //The display name for the field is set to "Last Name".
    //An error message will display if any validation rule is not met.
    [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must only contain letters, no special characters or spaces.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    //The field is required (cannot be empty).
    //The first name must have a minimum length of 2 characters and a maximum length of 20 characters.
    //The first name must match the regular expression, ensuring only alphabetic characters (no special characters or spaces) are allowed.
    //The display name for the field is set to "First Name".
    //An error message will display if any validation rule is not met.
    [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must only contain letters, no special characters or spaces.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    //The phone number is required (cannot be empty)
    //It must match the regular expression for a valid international phone number format, allowing optional country code (+64) and proper formatting
    //An error message will display if the phone number doesn't meet the specified format
    [Required, RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Invalid phone number format (please include +64)")]
    public string Phone { get; set; }

    public ICollection<Booking>? Bookings { get; set; }
}


