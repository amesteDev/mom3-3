using Microsoft.EntityFrameworkCore;
using songlistApi.Models;

namespace songlistApi.Data {
    public class SonglistContext : DbContext {
        public SonglistContext(DbContextOptions<SonglistContext> options) : base (options)
        {
            
        }

        public DbSet<Songlist> Songlist {get; set;}
    }
}