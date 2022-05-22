using Microsoft.EntityFrameworkCore;

namespace NewsSearchWebApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<News> News { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
    }
}
