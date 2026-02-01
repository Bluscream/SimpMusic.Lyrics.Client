# IO.Swagger.Api.LyricsApi

All URIs are relative to *https://api-lyrics.simpmusic.org*

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

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetLyricsByVideoIdExample
    {
        public void main()
        {
            var apiInstance = new LyricsApi();
            var videoId = videoId_example;  // string | YouTube video ID
            var limit = 56;  // int? | Maximum number of results to return (optional) 
            var offset = 56;  // int? | Number of results to skip (optional) 

            try
            {
                // Get Lyrics by Video ID
                LyricsResponse result = apiInstance.GetLyricsByVideoId(videoId, limit, offset);
                Debug.WriteLine(result);
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

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
