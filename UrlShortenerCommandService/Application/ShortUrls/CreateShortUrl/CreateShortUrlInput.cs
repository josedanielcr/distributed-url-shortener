namespace Application.ShortUrls.CreateShortUrl;

public class CreateShortUrlInput
{
    public required string OriginalUrl { get; init; }
    public required string HostMachine { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
}