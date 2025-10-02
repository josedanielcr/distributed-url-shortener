namespace Api.Contracts.Requests;

public class CreateShortUrlReq
{
    public required string OriginalUrl { get; init; }
}