using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class HomeFurnishingsDbContext : DbContext
    {
        public HomeFurnishingsDbContext(DbContextOptions<HomeFurnishingsDbContext> options) : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }

    }
}
