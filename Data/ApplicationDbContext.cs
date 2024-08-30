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
    }
}
