using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
