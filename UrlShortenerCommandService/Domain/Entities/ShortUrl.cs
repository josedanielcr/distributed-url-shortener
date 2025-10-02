namespace Domain.Entities;

public class ShortUrl
{
    public required int Id { get; set; }
    public required string OriginalUrl { get; init; }
    public required string ShortenedUrl { get; init; }
    public required string HostMachine { get; init; }
    public required DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; set; }
}