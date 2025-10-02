using Domain.Entities;
namespace Application.ShortUrls.CreateShortUrl;

public interface ICreateShortUrlService
{
    Task<int?> CreateShortUrl(CreateShortUrlInput shortUrl);
}