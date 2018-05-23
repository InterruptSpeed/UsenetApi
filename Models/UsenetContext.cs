using Microsoft.EntityFrameworkCore;

namespace UsenetApi.Models
{
    public partial class UsenetContext : DbContext
    {
        public UsenetContext(DbContextOptions<UsenetContext> options)
        :base(options)
        { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Article> Articles {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable("Groups", "UsenetSchema");

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Article>().ToTable("Articles", "UsenetSchema");

            modelBuilder.Entity<Article>()
                .HasOne(p => p.Group)
                .WithMany(b => b.Articles)
                .HasForeignKey(b => b.GroupId);

            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Subject).IsRequired();
            });

        }
    }
}