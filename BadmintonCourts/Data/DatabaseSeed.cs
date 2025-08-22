using BadmintonCourts.Areas.Identity.Data;
using BadmintonCourts.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonCourts.Data
{
    public static class DatabaseSeed
    {
        public static async Task SeedDataAsync(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<BadmintonCourtsDbContext>();
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<BadmintonCourtsUser>>();

            // Ensure database is created
            context.Database.EnsureCreated();

            // Prevent duplicate seeding
            if (context.Locations.Any() || context.Bookings.Any() || context.Courts.Any() || context.Equipments.Any() || context.Payments.Any())
                return;

            // Seed Locations
            var locations = new Location[]
            {
                new Location { LocationName = "Auckland Badminton Center", Addresss = "12 Badminton Lane", Suburb = "Central", City = "Auckland", PostalCode = "1010", PhoneNumber = "+64 9 123 4567" },
                new Location { LocationName = "Wellington Shuttle Club", Addresss = "45 Shuttle Rd", Suburb = "Eastside", City = "Wellington", PostalCode = "6011", PhoneNumber = "+64 4 234 5678" },
                new Location { LocationName = "Christchurch Racket Hall", Addresss = "78 Racket Ave", Suburb = "Westville", City = "Christchurch", PostalCode = "8011", PhoneNumber = "+64 3 345 6789" },
                new Location { LocationName = "Hamilton Sports Complex", Addresss = "101 Sport St", Suburb = "Baytown", City = "Hamilton", PostalCode = "3200", PhoneNumber = "+64 7 456 7890" },
                new Location { LocationName = "Dunedin Shuttle Hub", Addresss = "202 Shuttle Blvd", Suburb = "Midtown", City = "Dunedin", PostalCode = "9010", PhoneNumber = "+64 3 567 8901" }
            };
            context.Locations.AddRange(locations);
            await context.SaveChangesAsync();

            // Seed Users via UserManager
            var usersToCreate = new (string FirstName, string LastName, string Email, string Phone)[]
            {
                ("John", "Doe", "JohnDoe@gmail.com", "+640278321892"),
                ("Jane", "Doe", "JaneDoe@gmail.com", "+640229122832"),
                ("Alice", "Smith", "AliceSmith@gmail.com", "+64211234567"),
                ("Bob", "Brown", "BobBrown@gmail.com", "+64212345678"),
                ("Emma", "Taylor", "EmmaTaylor@gmail.com", "+64213456789")
            };

            var createdUsers = new List<BadmintonCourtsUser>();

            foreach (var u in usersToCreate)
            {
                var existingUser = await userManager.FindByEmailAsync(u.Email);
                if (existingUser == null)
                {
                    var user = new BadmintonCourtsUser
                    {
                        UserName = u.Email,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Phone = u.Phone
                    };
                    var result = await userManager.CreateAsync(user, "DefaultPassword123!");
                    if (result.Succeeded)
                    {
                        createdUsers.Add(user);
                    }
                }
                else
                {
                    createdUsers.Add(existingUser);
                }
            }

            // Seed Courts
            var courts = new Court[]
            {
                new Court { CourtName = "Badminton Court 1", Price = 12.00m, LocationID = locations[0].LocationsID },
                new Court { CourtName = "Badminton Court 2", Price = 14.00m, LocationID = locations[0].LocationsID },
                new Court { CourtName = "Badminton Court 3", Price = 13.50m, LocationID = locations[1].LocationsID },
                new Court { CourtName = "Badminton Court 4", Price = 15.00m, LocationID = locations[2].LocationsID },
                new Court { CourtName = "Badminton Court 5", Price = 11.50m, LocationID = locations[3].LocationsID }
            };
            context.Courts.AddRange(courts);
            await context.SaveChangesAsync();

            // Seed Equipments
            var equipments = new Equipment[]
            {
                new Equipment { EName = "Yonex Astrox 100ZZ", EType = "Racket", EPrice = 5.00m },
                new Equipment { EName = "Yonex - 12 Shuttlecocks per Pack", EType = "Shuttlecock", EPrice = 15.00m },
                new Equipment { EName = "Li-Ning - 12 Shuttlecocks per Pack", EType = "Shuttlecock", EPrice = 25.00m },
                new Equipment { EName = "Victor - 12 Shuttlecocks per Pack", EType = "Shuttlecock", EPrice = 10.00m }
            };
            context.Equipments.AddRange(equipments);
            await context.SaveChangesAsync();

            // Seed Bookings (use real user IDs from created users)
            var bookings = new Booking[]
            {
                new Booking
                {
                    BadmintonCourtsUserId = createdUsers[0].Id,
                    CourtID = courts[1].CourtID,
                    EquipmentID = equipments[1].EquipmentID, // Shuttlecock pack
                    BookingDate = new DateTime(2025, 9, 10),
                    StartTime = new DateTime(2025, 9, 10, 9, 0, 0),
                    EndTime = new DateTime(2025, 9, 10, 10, 0, 0),
                    TotalPrice = courts[0].Price + equipments[1].EPrice
                },
                new Booking
                {
                    BadmintonCourtsUserId = createdUsers[1].Id,
                    CourtID = courts[1].CourtID,
                    EquipmentID = equipments[1].EquipmentID, // Racket
                    BookingDate = new DateTime(2025, 9, 11),
                    StartTime = new DateTime(2025, 9, 11, 13, 30, 0),
                    EndTime = new DateTime(2025, 9, 11, 14, 30, 0),
                    TotalPrice = courts[1].Price + equipments[0].EPrice
                },
                new Booking
                {
                    BadmintonCourtsUserId = createdUsers[2].Id,
                    CourtID = courts[2].CourtID,
                    EquipmentID = equipments[1].EquipmentID,
                    BookingDate = new DateTime(2025, 9, 12),
                    StartTime = new DateTime(2025, 9, 12, 16, 0, 0),
                    EndTime = new DateTime(2025, 9, 12, 17, 0, 0),
                    TotalPrice = courts[2].Price
                },
                new Booking
                {
                    BadmintonCourtsUserId = createdUsers[3].Id,
                    CourtID = courts[3].CourtID,
                    EquipmentID = equipments[4].EquipmentID, // Shoes
                    BookingDate = new DateTime(2025, 9, 13),
                    StartTime = new DateTime(2025, 9, 13, 10, 0, 0),
                    EndTime = new DateTime(2025, 9, 13, 11, 0, 0),
                    TotalPrice = courts[3].Price + equipments[4].EPrice
                },
                new Booking
                {
                    BadmintonCourtsUserId = createdUsers[4].Id,
                    CourtID = courts[4].CourtID,
                    EquipmentID = equipments[2].EquipmentID, // Grip Tape
                    BookingDate = new DateTime(2025, 9, 14),
                    StartTime = new DateTime(2025, 9, 14, 15, 0, 0),
                    EndTime = new DateTime(2025, 9, 14, 16, 0, 0),
                    TotalPrice = courts[4].Price + equipments[2].EPrice
                }
            };
            context.Bookings.AddRange(bookings);
            await context.SaveChangesAsync();

            // Seed Payments
            var payments = new Payment[]
            {
                new Payment { BookingID = bookings[0].BookingID, PaymentAmount = bookings[0].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
                new Payment { BookingID = bookings[1].BookingID, PaymentAmount = bookings[1].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
                new Payment { BookingID = bookings[2].BookingID, PaymentAmount = bookings[2].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
                new Payment { BookingID = bookings[3].BookingID, PaymentAmount = bookings[3].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" },
                new Payment { BookingID = bookings[4].BookingID, PaymentAmount = bookings[4].TotalPrice, PaymentDate = DateTime.Today, PaymentStatus = "Paid" }
            };
            context.Payments.AddRange(payments);
            await context.SaveChangesAsync();
        }
    }
}
