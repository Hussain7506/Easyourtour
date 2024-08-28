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
    }
}
