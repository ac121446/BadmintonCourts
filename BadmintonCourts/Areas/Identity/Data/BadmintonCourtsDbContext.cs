using BadmintonCourts.Areas.Identity.Data;
using BadmintonCourts.Models;
using BadmintonRentals.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BadmintonCourts.Areas.Identity.Data;

public class BadmintonCourtsDbContext : IdentityDbContext<BadmintonCourtsUser>
{
    public BadmintonCourtsDbContext(DbContextOptions<BadmintonCourtsDbContext> options) : base(options)
    {
    }

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Court> Courts { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Court>().ToTable("Court");
        modelBuilder.Entity<Booking>().ToTable("Booking");
        modelBuilder.Entity<Equipment>().ToTable("Equipment");
        modelBuilder.Entity<Location>().ToTable("Location");
        modelBuilder.Entity<Payment>().ToTable("Payment");
    }
}
