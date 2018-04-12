using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Data.EntityFramework
{
    public class MusicStoreDbContext : DbContext
    {
        public MusicStoreDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Venue> Venues { get; set; }
    }
}