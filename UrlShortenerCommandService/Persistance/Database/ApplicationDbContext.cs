using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Persistance.Database;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public DbSet<ShortUrl> ShortUrls { get; set; }
}