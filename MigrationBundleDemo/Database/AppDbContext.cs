using Microsoft.EntityFrameworkCore;
using MigrationBundleDemo.Models;

namespace MigrationBundleDemo.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasIndex(p => p.Id);

        modelBuilder.Entity<Person>().HasIndex(p => p.UserName).IsUnique();

        modelBuilder
            .Entity<Person>()
            .HasData(
                new Person
                {
                    Id = Guid.NewGuid(),
                    UserName = "jtodd",
                    FullName = "Jason Todd"
                }
            );

        base.OnModelCreating(modelBuilder);
    }
}
