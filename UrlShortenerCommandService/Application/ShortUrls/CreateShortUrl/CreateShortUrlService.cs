using Domain.Entities;
using Domain.Repository;

namespace Application.ShortUrls.CreateShortUrl;

public class CreateShortUrlService(IShortUrlRepository urlRepository) : ICreateShortUrlService
{
    public async Task<int?> CreateShortUrl(CreateShortUrlInput shortUrlInput)
    {
        var shortUrl = new ShortUrl
        {
            Id = 0,
            OriginalUrl = shortUrlInput.OriginalUrl,
            ShortenedUrl = "hello world",
            CreatedAt = shortUrlInput.CreatedAt,
            HostMachine = shortUrlInput.HostMachine,
            UpdatedAt = null
        };
        return await urlRepository.AddShortUrlAsync(shortUrl);
    }
}