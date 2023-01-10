using Microsoft.EntityFrameworkCore;

namespace FootballCatalog.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Footballer> Footballers { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Gender> Genders { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, Name = Country.Russia },
            new Country { Id = 2, Name = Country.Italy },
            new Country { Id = 3, Name = Country.Usa }
        );
        modelBuilder.Entity<Gender>().HasData(
            new Gender { Id = 1, Name = Gender.Male },
            new Gender { Id = 2, Name = Gender.Female }
        );
        modelBuilder.Entity<Team>().HasData(
            new Team { Id = 1, Name = "Урал" },
            new Team { Id = 2, Name = "Барселона" }
            );
    }
}