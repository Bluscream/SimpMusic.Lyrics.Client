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
var lyrics = await api.GetLyricsByVideoIdAsync("ZFIWU2jx7yM");

if (lyrics != null)
{
    Console.WriteLine($"Song: {lyrics.SongTitle}");
    Console.WriteLine($"Artist: {lyrics.ArtistName}");
    Console.WriteLine($"Lyrics:\n{lyrics.PlainLyric}");
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
- `CreateLyricAsync(body)` - Create new lyric (requires HMAC auth)

### Translations

- `GetTranslatedLyricsByVideoIdAsync(videoId)` - Get all translations for a video
- `GetTranslatedLyricsByVideoIdAndLanguageAsync(videoId, language)` - Get translation in specific language
- `CreateTranslatedLyricAsync(body)` - Create new translation (requires HMAC auth)

### Search

- `SearchLyricsAsync(query, limit?, offset?)` - Search lyrics by query
- `SearchLyricsByTitleAsync(title, limit?, offset?)` - Search by song title
- `SearchLyricsByArtistAsync(artist, limit?, offset?)` - Search by artist name

### Voting

- `VoteForLyricAsync(body)` - Vote for a lyric (requires HMAC auth)
- `VoteForTranslatedLyricAsync(body)` - Vote for a translation (requires HMAC auth)

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
