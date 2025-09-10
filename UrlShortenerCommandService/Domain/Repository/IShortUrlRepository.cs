using Domain.Entities;

namespace Domain.Repository;

public interface IShortUrlRepository
{
    Task<int?> AddShortUrlAsync(ShortUrl shortUrl);
}