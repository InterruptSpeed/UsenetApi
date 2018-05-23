using Microsoft.EntityFrameworkCore;

namespace UsenetApi.Models
{
    public class UsenetDbContext : DbContext
    {
        public UsenetDbContext(DbContextOptions<UsenetDbContext> options)
            : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
    }
}