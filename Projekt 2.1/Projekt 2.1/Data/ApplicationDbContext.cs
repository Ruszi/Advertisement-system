using Microsoft.EntityFrameworkCore;
using Projekt_2._1.Models;

namespace Projekt_2._1.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Konstruktor DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet dla mieszkań
        public DbSet<Apartment> Apartments { get; set; }

        // DbSet dla ogłoszeń
        public DbSet<Advertisement> Advertisements { get; set; }
    }
}
