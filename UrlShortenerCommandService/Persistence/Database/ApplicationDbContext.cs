using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Persistence.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    public DbSet<ShortUrl> ShortUrls { get; set; }
}