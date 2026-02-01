# SimpMusic.Lyrics.Client

A .NET client library for the [SimpMusic Lyrics API](https://github.com/maxrave-dev/lyrics). Provides easy access to lyrics and translations for songs.

## Features

- 🎵 Get lyrics by YouTube video ID
- 🌍 Support for translated lyrics in multiple languages
- 🔍 Search lyrics by title, artist, or query
- ⬆️ Submit new lyrics and translations (requires HMAC authentication)
- 👍 Vote for lyrics and translations
- ⚡ Fully async/await support
- 📦 .NET Standard 2.0 compatible

## Installation

Install via NuGet:

```bash
dotnet add package SimpMusic.Lyrics.Client
```

Or via Package Manager:

```powershell
Install-Package SimpMusic.Lyrics.Client
```

## Quick Start

```csharp
using SimpMusic.Lyrics.Client.Api;
using SimpMusic.Lyrics.Client.Model;

// Create API instance
var api = new LyricsApi();

// Get lyrics by video ID
// Note: The API returns lyrics in a wrapper format with a data array
// The client automatically extracts the first item for GetLyricsByVideoIdAsync
var lyrics = await api.GetLyricsByVideoIdAsync("Y9SmNz2RofI");

if (lyrics != null && !string.IsNullOrWhiteSpace(lyrics.PlainLyric))
{
    Console.WriteLine($"Song: {lyrics.SongTitle}");
    Console.WriteLine($"Artist: {lyrics.ArtistName}");
    Console.WriteLine($"Lyrics:\n{lyrics.PlainLyric}");
}
else
{
    Console.WriteLine("No lyrics found for this video.");
}

// Search for lyrics
var searchApi = new SearchApi();
var searchResults = await searchApi.SearchLyricsAsync("demons", limit: 5);

if (searchResults != null && searchResults.Data != null && searchResults.Data.Count > 0)
{
    Console.WriteLine($"Found {searchResults.Data.Count} results:");
    foreach (var result in searchResults.Data)
    {
        Console.WriteLine($"- {result.SongTitle} by {result.ArtistName}");
    }
}
```

## Rate Limiting

The API enforces rate limiting:
- **30 requests per minute** per IP address
- Rate limit headers are included in all responses:
  - `X-RateLimit-Limit`: Maximum requests allowed
  - `X-RateLimit-Remaining`: Remaining requests in current window
  - `X-RateLimit-Reset`: Unix timestamp when limit resets
- When exceeded, returns HTTP 429 with `Retry-After` header

## API Endpoints

### Lyrics

- `GetLyricsByVideoIdAsync(videoId, limit?, offset?)` - Get lyrics by YouTube video ID
  - **Note:** The API returns lyrics in a wrapper format `{"type": "success", "data": [{...}], "success": true}`. The client automatically extracts the first item from the `data` array.
- `CreateLyricAsync(body)` - Create new lyric (requires HMAC auth)

### Translations

- `GetTranslatedLyricsByVideoIdAsync(videoId)` - Get all translations for a video
  - Returns `TranslatedLyricsListResponse` with `Data` array containing all translations
- `GetTranslatedLyricsByVideoIdAndLanguageAsync(videoId, language)` - Get translation in specific language
  - Returns `TranslatedLyricsListResponse` with `Data` array
- `CreateTranslatedLyricAsync(body)` - Create new translation (requires HMAC auth)

### Search

- `SearchLyricsAsync(query, limit?, offset?)` - Search lyrics by query
  - Returns `LyricsListResponse` with `Data` array containing search results
- `SearchLyricsByTitleAsync(title, limit?, offset?)` - Search by song title
  - Returns `LyricsListResponse` with `Data` array
- `SearchLyricsByArtistAsync(artist, limit?, offset?)` - Search by artist name
  - Returns `LyricsListResponse` with `Data` array

### Voting

- `VoteForLyricAsync(body)` - Vote for a lyric (requires HMAC auth)
- `VoteForTranslatedLyricAsync(body)` - Vote for a translation (requires HMAC auth)

## API Response Format

All API endpoints return responses in a wrapper format:

```json
{
  "type": "success",
  "data": [...],
  "success": true
}
```

- **GetLyricsByVideoIdAsync**: Returns a single `LyricsResponse` (client extracts first item from `data` array)
- **Search endpoints**: Return `LyricsListResponse` with `Data` array containing multiple results
- **Translation endpoints**: Return `TranslatedLyricsListResponse` with `Data` array containing translations

## HMAC Authentication

For POST/PUT/DELETE operations, HMAC authentication is required. Configure it:

```csharp
var config = new Configuration();
config.ApiKey.Add("X-HMAC", "your-hmac-token");
config.ApiKey.Add("X-Timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString());

var api = new LyricsApi(config);
```

## Documentation

Full API documentation is available at:
- [SimpMusic Lyrics API](https://github.com/maxrave-dev/lyrics)
- [OpenAPI Specification](https://api-lyrics.simpmusic.org)

## Requirements

- .NET Standard 2.0 or later
- RestSharp 111.4.1+
- Newtonsoft.Json 13.0.1+

## License

This library is provided as-is. The SimpMusic Lyrics API is licensed under GPL-3.0.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Links

- [GitHub Repository](https://github.com/Bluscream/SimpMusic.Lyrics.Client)
- [NuGet Package](https://www.nuget.org/packages/SimpMusic.Lyrics.Client)
- [SimpMusic Lyrics API](https://github.com/maxrave-dev/lyrics)
