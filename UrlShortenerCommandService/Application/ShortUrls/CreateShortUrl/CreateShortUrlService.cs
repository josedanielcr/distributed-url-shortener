using Domain.Repository;

namespace Application.ShortUrls.CreateShortUrl;

public class CreateShortUrlService(IShortUrlRepository urlRepository) : ICreateShortUrlService
{
    private readonly IShortUrlRepository _urlRepository = urlRepository;

    public Task<int?> CreateShortUrl(Domain.Entities.ShortUrl shortUrl)
    {
        throw new NotImplementedException();
    }
}