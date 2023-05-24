using Microsoft.EntityFrameworkCore;
using NZWalks_WebAPI__Project.Models.Domain;

namespace NZWalks_WebAPI__Project.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
    }
}
