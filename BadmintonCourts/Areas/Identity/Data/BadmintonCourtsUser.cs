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
    

    [Required(ErrorMessage = "Enter your first name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Enter your last name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Enter your phone number")]
    public string PhoneNumber { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}


