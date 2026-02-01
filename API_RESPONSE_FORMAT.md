# SimpMusic Lyrics API Response Format

## Overview

All API endpoints return responses in a consistent wrapper format:

```json
{
  "type": "success",
  "data": [...],
  "success": true
}
```

The `type` field is informational and is ignored during deserialization. Only `data` and `success` are mapped to the client models.

## Endpoint-Specific Behavior

### GetLyricsByVideoId (`GET /v1/{videoId}`)

**API Response:**
```json
{
  "type": "success",
  "data": [
    {
      "id": "6882d066000aeeecd72f",
      "videoId": "Y9SmNz2RofI",
      "songTitle": "This Is My Kingdom Come",
      "artistName": "Demons Running",
      "plainLyric": "...",
      "syncedLyrics": "...",
      ...
    }
  ],
  "success": true
}
```

**Client Behavior:**
- The client deserializes the response as `LyricsListResponse`
- Extracts the first item from the `data` array
- Returns it as a single `LyricsResponse` object

**Code Location:** `src/SimpMusic.Lyrics.Client/Api/LyricsApi.cs` - `GetLyricsByVideoIdAsyncWithHttpInfo`

### Search Endpoints (`GET /v1/search`, `/v1/search/title`, `/v1/search/artist`)

**API Response:**
```json
{
  "type": "success",
  "data": [
    {
      "id": "...",
      "videoId": "...",
      "songTitle": "...",
      "artistName": "...",
      ...
    },
    ...
  ],
  "success": true
}
```

**Client Behavior:**
- The client deserializes directly as `LyricsListResponse`
- Returns the full `LyricsListResponse` with `Data` array containing all results

**Code Location:** `src/SimpMusic.Lyrics.Client/Api/SearchApi.cs` - All search methods

### Translation Endpoints (`GET /v1/translated/{videoId}`, `/v1/translated/{videoId}/{language}`)

**API Response:**
```json
{
  "type": "success",
  "data": [
    {
      "id": "...",
      "videoId": "...",
      "translatedLyric": "...",
      "language": "...",
      ...
    },
    ...
  ],
  "success": true
}
```

**Client Behavior:**
- The client deserializes directly as `TranslatedLyricsListResponse`
- Returns the full `TranslatedLyricsListResponse` with `Data` array containing all translations

**Code Location:** `src/SimpMusic.Lyrics.Client/Api/TranslationsApi.cs` - Translation get methods

## Error Responses

When an error occurs, the API returns:

```json
{
  "type": "error",
  "error": {
    "error": true,
    "code": 404,
    "reason": "Lyrics not found for the given video ID"
  },
  "success": false
}
```

The client throws an `ApiException` with the appropriate error code.

## Testing

All endpoints have been tested with curl:

```bash
# Get lyrics by video ID
curl "https://api-lyrics.simpmusic.org/v1/Y9SmNz2RofI"

# Search lyrics
curl "https://api-lyrics.simpmusic.org/v1/search?q=demons&limit=5"

# Get translations
curl "https://api-lyrics.simpmusic.org/v1/translated/Y9SmNz2RofI/en"
```

## SSL Configuration

The client is configured to handle SSL/TLS connections properly:
- SSL certificate validation callback configured in `ApiClient.cs`
- All `RestClient` instances use `RestClientOptions` with SSL settings

## Notes

- The `type` field in API responses is ignored during deserialization
- Only `data` and `success` fields are mapped to client models
- `GetLyricsByVideoId` is the only endpoint that extracts a single item from the `data` array
- All other endpoints return list responses directly
