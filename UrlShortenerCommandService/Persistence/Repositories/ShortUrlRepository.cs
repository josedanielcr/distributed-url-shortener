using Domain.Entities;
using Domain.Repository;
using Persistence.Database;

namespace Persistence.Repositories;

public class ShortUrlRepository(ApplicationDbContext dbContext) : IShortUrlRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public Task<int?> AddShortUrlAsync(ShortUrl shortUrl)
    {
        throw new NotImplementedException();
    }
}