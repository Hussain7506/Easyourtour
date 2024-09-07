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
        public DbSet<DayItinerary> DayItineraries { get; set; }
        public DbSet<DayItinerarySightseeing> DayItinerarySightseeings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure DayItinerary relationships with DeleteBehavior.Restrict or SetNull
            modelBuilder.Entity<DayItinerary>()
                .HasOne(di => di.HotelRoom)
                .WithMany()
                .HasForeignKey(di => di.HotelRoomId)
                .OnDelete(DeleteBehavior.Restrict); // No cascade delete

            modelBuilder.Entity<DayItinerary>()
                .HasOne(di => di.Hotel)
                .WithMany()
                .HasForeignKey(di => di.HotelId)
                .OnDelete(DeleteBehavior.Restrict); // No cascade delete

            modelBuilder.Entity<DayItinerary>()
                .HasOne(di => di.Location)
                .WithMany()
                .HasForeignKey(di => di.LocationId)
                .OnDelete(DeleteBehavior.Restrict); // No cascade delete

           

            modelBuilder.Entity<DayItinerary>()
                .HasOne(di => di.Destination)
                .WithMany()
                .HasForeignKey(di => di.DestinationId)
                .OnDelete(DeleteBehavior.Restrict); // No cascade delete

            // Composite primary key configuration for DayItinerarySightseeing
            modelBuilder.Entity<DayItinerarySightseeing>()
                .HasKey(ds => new { ds.DayItineraryId, ds.SightseeingId });



            modelBuilder.Entity<DayItinerarySightseeing>()
                .HasOne(ds => ds.Sightseeing)
                .WithMany()
                .HasForeignKey(ds => ds.SightseeingId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
