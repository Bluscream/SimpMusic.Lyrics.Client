# SimpMusic.Lyrics.Client.Api.LyricsApi

All URIs are relative to *https://api-lyrics.simpmusic.org*

**Note:** All API endpoints return responses in a wrapper format:
```json
{
  "type": "success",
  "data": [...],
  "success": true
}
```

The `type` field is ignored during deserialization. The client automatically handles the wrapper format.

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateLyric**](LyricsApi.md#createlyric) | **POST** /v1 | Create New Lyric
[**GetLyricsByVideoId**](LyricsApi.md#getlyricsbyvideoid) | **GET** /v1/{videoId} | Get Lyrics by Video ID

<a name="createlyric"></a>
# **CreateLyric**
> CreateLyricResponse CreateLyric (CreateLyricRequest body)

Create New Lyric

Creates a new lyric entry with the provided lyric data. Requires HMAC authentication.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateLyricExample
    {
        public void main()
        {
            // Configure API key authorization: hmacAuth
            Configuration.Default.AddApiKey("X-HMAC", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-HMAC", "Bearer");

            var apiInstance = new LyricsApi();
            var body = new CreateLyricRequest(); // CreateLyricRequest | 

            try
            {
                // Create New Lyric
                CreateLyricResponse result = apiInstance.CreateLyric(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LyricsApi.CreateLyric: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**CreateLyricRequest**](CreateLyricRequest.md)|  | 

### Return type

[**CreateLyricResponse**](CreateLyricResponse.md)

### Authorization

[hmacAuth](../README.md#hmacAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getlyricsbyvideoid"></a>
# **GetLyricsByVideoId**
> LyricsResponse GetLyricsByVideoId (string videoId, int? limit = null, int? offset = null)

Get Lyrics by Video ID

Fetches lyrics associated with a specific video ID. Optionally supports pagination with limit and offset.

**Note:** The API returns lyrics in a wrapper format `{"type": "success", "data": [{...}], "success": true}`. The client automatically extracts the first item from the `data` array and returns it as a `LyricsResponse`.

### Example
```csharp
using System;
using System.Diagnostics;
using SimpMusic.Lyrics.Client.Api;
using SimpMusic.Lyrics.Client.Client;
using SimpMusic.Lyrics.Client.Model;

namespace Example
{
    public class GetLyricsByVideoIdExample
    {
        public void main()
        {
            var apiInstance = new LyricsApi();
            var videoId = "Y9SmNz2RofI";  // string | YouTube video ID
            var limit = 56;  // int? | Maximum number of results to return (optional) 
            var offset = 56;  // int? | Number of results to skip (optional) 

            try
            {
                // Get Lyrics by Video ID
                // The API returns: {"type": "success", "data": [{...}], "success": true}
                // The client extracts the first item from the data array
                LyricsResponse result = await apiInstance.GetLyricsByVideoIdAsync(videoId, limit, offset);
                
                if (result != null && !string.IsNullOrWhiteSpace(result.PlainLyric))
                {
                    Debug.WriteLine($"Song: {result.SongTitle}");
                    Debug.WriteLine($"Artist: {result.ArtistName}");
                    Debug.WriteLine($"Lyrics: {result.PlainLyric}");
                }
                else
                {
                    Debug.WriteLine("No lyrics found for this video.");
                }
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LyricsApi.GetLyricsByVideoId: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **videoId** | **string**| YouTube video ID | 
 **limit** | **int?**| Maximum number of results to return | [optional] 
 **offset** | **int?**| Number of results to skip | [optional] 

### Return type

[**LyricsResponse**](LyricsResponse.md)

**API Response Format:**
The actual API returns:
```json
{
  "type": "success",
  "data": [
    {
      "id": "...",
      "videoId": "...",
      "songTitle": "...",
      "artistName": "...",
      "plainLyric": "...",
      "syncedLyrics": "...",
      ...
    }
  ],
  "success": true
}
```

The client automatically extracts the first item from the `data` array.

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
