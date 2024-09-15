using Easyourtour.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Easyourtour.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationImage> LocationImages { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelRoomImage> HotelRoomImages { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Sightseeing> Sightseeings { get; set; }
        public DbSet<SightseeingImage> SightseeingImages { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<HotelDestinationOption> HotelDestinationOptions { get; set; }
        public DbSet<TravelSightseeingOption> TravelSightseeingOptions { get; set; }
        public DbSet<HotelDestinationDay> HotelDestinationDays { get; set; } // Add this line
        public DbSet<TravelSightseeingDay> TravelSightseeingDays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure HotelDestinationDay -> Hotel relationship
            modelBuilder.Entity<HotelDestinationDay>()
                .HasOne(h => h.Hotel)
                .WithMany()
                .HasForeignKey(h => h.HotelId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict or NoAction to prevent cascade delete

            // Configure HotelDestinationDay -> HotelRoom relationship
            modelBuilder.Entity<HotelDestinationDay>()
                .HasOne(h => h.HotelRoom)
                .WithMany()
                .HasForeignKey(h => h.HotelRoomId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict or NoAction to prevent cascade delete

            // Optionally configure other foreign keys similarly if needed.
            // Configure HotelDestinationDay -> Location relationship
            modelBuilder.Entity<HotelDestinationDay>()
                .HasOne(h => h.Location)
                .WithMany()
                .HasForeignKey(h => h.LocationId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete
        }


    }
}
