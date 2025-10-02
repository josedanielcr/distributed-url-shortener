using Domain.Entities;
using Domain.Repository;

namespace Application.ShortUrls.CreateShortUrl;

public class CreateShortUrlService(IShortUrlRepository urlRepository) : ICreateShortUrlService
{
    private readonly IShortUrlRepository _urlRepository = urlRepository;

    public async Task<int?> CreateShortUrl(ShortUrl shortUrl)
    {
        throw new NotImplementedException();
    }
}