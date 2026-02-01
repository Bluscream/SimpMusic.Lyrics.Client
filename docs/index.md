# SimpMusic.Lyrics.Client Documentation

A .NET client library for the SimpMusic Lyrics API. Provides easy access to lyrics and translations for songs.

## API Documentation

### API Classes

- **[LyricsApi](LyricsApi.md)** - Get lyrics by YouTube video ID and create new lyrics
- **[SearchApi](SearchApi.md)** - Search lyrics by title, artist, or query
- **[TranslationsApi](TranslationsApi.md)** - Get and create translated lyrics
- **[VotingApi](VotingApi.md)** - Vote for lyrics and translations

### Models

- **[LyricsResponse](LyricsResponse.md)** - Response containing lyrics data
- **[LyricsListResponse](LyricsListResponse.md)** - Response containing a list of lyrics
- **[TranslatedLyric](TranslatedLyric.md)** - Translated lyric data
- **[TranslatedLyricsListResponse](TranslatedLyricsListResponse.md)** - Response containing translated lyrics
- **[CreateLyricRequest](CreateLyricRequest.md)** - Request model for creating lyrics
- **[CreateLyricResponse](CreateLyricResponse.md)** - Response model for lyric creation
- **[CreateTranslatedLyricRequest](CreateTranslatedLyricRequest.md)** - Request model for creating translations
- **[CreateTranslatedLyricResponse](CreateTranslatedLyricResponse.md)** - Response model for translation creation
- **[VoteRequest](VoteRequest.md)** - Request model for voting
- **[SuccessResponse](SuccessResponse.md)** - Generic success response
- **[ErrorResponse](ErrorResponse.md)** - Error response model
- **[ErrorResponseError](ErrorResponseError.md)** - Error details

## Quick Start

```csharp
using SimpMusic.Lyrics.Client.Api;
using SimpMusic.Lyrics.Client.Model;

// Create API instance
var api = new LyricsApi();

// Get lyrics by video ID
var lyrics = await api.GetLyricsByVideoIdAsync("ZFIWU2jx7yM");

if (lyrics != null)
{
    Console.WriteLine($"Song: {lyrics.SongTitle}");
    Console.WriteLine($"Artist: {lyrics.ArtistName}");
    Console.WriteLine($"Lyrics:\n{lyrics.PlainLyric}");
}
```

## Installation

Install via NuGet:

```bash
dotnet add package SimpMusic.Lyrics.Client
```

Or via Package Manager:

```powershell
Install-Package SimpMusic.Lyrics.Client
```

## Rate Limiting

The API enforces rate limiting:

- **30 requests per minute** per IP address
- Rate limit headers are included in all responses:
  - `X-RateLimit-Limit`: Maximum requests allowed
  - `X-RateLimit-Remaining`: Remaining requests in current window
  - `X-RateLimit-Reset`: Unix timestamp when limit resets
- When exceeded, returns HTTP 429 with `Retry-After` header

## HMAC Authentication

For POST/PUT/DELETE operations, HMAC authentication is required:

```csharp
var config = new Configuration();
config.ApiKey.Add("X-HMAC", "your-hmac-token");
config.ApiKey.Add("X-Timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString());

var api = new LyricsApi(config);
```

## OpenAPI Specification

The complete OpenAPI specification is available: [openapi.json](openapi.json)

## Links

- [GitHub Repository](https://github.com/Bluscream/SimpMusic.Lyrics.Client)
- [NuGet Package](https://www.nuget.org/packages/SimpMusic.Lyrics.Client)
- [SimpMusic Lyrics API](https://lyrics.simpmusic.org/api)

## License

This library is provided as-is. The SimpMusic Lyrics API is licensed under GPL-3.0.
