using Application.ShortUrls.CreateShortUrl;
using Domain.Entities;
using Domain.Repository;
using Moq;

namespace Application.Tests.ShortUrls.CreateShortUrl;

public class CreateShortUrlServiceTest
{
    [Fact]
    public async Task GivenValidUrl_WhenCreateShortUrl_ThenPersistsAndReturnsId()
    {
        //Arrange
        var shortUrl = new ShortUrl
        {
            Id = 1,
            OriginalUrl = "https://example.com/some/long/path?utm_source=test",
            ShortenedUrl = "abc123",
            HostMachine = "server-01",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        var mockShortUrlRepository = new Mock<IShortUrlRepository>();
        mockShortUrlRepository.Setup(repo => repo.AddShortUrlAsync(shortUrl))
            .ReturnsAsync(1);
        var createShortUrlService = new CreateShortUrlService(mockShortUrlRepository.Object);
        
        //Act
        var result = await createShortUrlService.CreateShortUrl(shortUrl);
        
        //Asserts
        result.Value.Equals(1);
    }
}