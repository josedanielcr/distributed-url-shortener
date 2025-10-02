using Domain.Entities;
using Domain.Repository;
using Persistence.Database;

namespace Persistence.Repositories;

public class ShortUrlRepository(ApplicationDbContext dbContext) : IShortUrlRepository
{
    public async Task<int?> AddShortUrlAsync(ShortUrl shortUrl)
    {
        await dbContext.ShortUrls.AddAsync(shortUrl);
        await dbContext.SaveChangesAsync();
        return shortUrl.Id;
    }
}