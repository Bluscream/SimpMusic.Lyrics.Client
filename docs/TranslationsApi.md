# SimpMusic.Lyrics.Client.Api.TranslationsApi

All URIs are relative to *https://api-lyrics.simpmusic.org*

**Note:** All translation endpoints return responses in a wrapper format with a `data` array containing translations.

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateTranslatedLyric**](TranslationsApi.md#createtranslatedlyric) | **POST** /v1/translated | Create Translated Lyric
[**GetTranslatedLyricsByVideoId**](TranslationsApi.md#gettranslatedlyricsbyvideoid) | **GET** /v1/translated/{videoId} | Get Translated Lyrics by Video ID
[**GetTranslatedLyricsByVideoIdAndLanguage**](TranslationsApi.md#gettranslatedlyricsbyvideoidandlanguage) | **GET** /v1/translated/{videoId}/{language} | Get Translated Lyrics by Video ID and Language

<a name="createtranslatedlyric"></a>
# **CreateTranslatedLyric**
> CreateTranslatedLyricResponse CreateTranslatedLyric (CreateTranslatedLyricRequest body)

Create Translated Lyric

Creates a new translated lyric entry. Requires HMAC authentication.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateTranslatedLyricExample
    {
        public void main()
        {
            // Configure API key authorization: hmacAuth
            Configuration.Default.AddApiKey("X-HMAC", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-HMAC", "Bearer");

            var apiInstance = new TranslationsApi();
            var body = new CreateTranslatedLyricRequest(); // CreateTranslatedLyricRequest | 

            try
            {
                // Create Translated Lyric
                CreateTranslatedLyricResponse result = apiInstance.CreateTranslatedLyric(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TranslationsApi.CreateTranslatedLyric: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**CreateTranslatedLyricRequest**](CreateTranslatedLyricRequest.md)|  | 

### Return type

[**CreateTranslatedLyricResponse**](CreateTranslatedLyricResponse.md)

### Authorization

[hmacAuth](../README.md#hmacAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettranslatedlyricsbyvideoid"></a>
# **GetTranslatedLyricsByVideoId**
> TranslatedLyricsListResponse GetTranslatedLyricsByVideoId (string videoId, int? limit = null, int? offset = null)

Get Translated Lyrics by Video ID

Fetches translated lyrics for a specific video ID with optional pagination using limit and offset parameters.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTranslatedLyricsByVideoIdExample
    {
        public void main()
        {
            var apiInstance = new TranslationsApi();
            var videoId = videoId_example;  // string | YouTube video ID
            var limit = 56;  // int? | Maximum number of results to return (optional) 
            var offset = 56;  // int? | Number of results to skip (optional) 

            try
            {
                // Get Translated Lyrics by Video ID
                TranslatedLyricsListResponse result = apiInstance.GetTranslatedLyricsByVideoId(videoId, limit, offset);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TranslationsApi.GetTranslatedLyricsByVideoId: " + e.Message );
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

[**TranslatedLyricsListResponse**](TranslatedLyricsListResponse.md)

**API Response Format:**
The actual API returns:
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
    }
  ],
  "success": true
}
```

The client deserializes this into a `TranslatedLyricsListResponse` with `Data` (array) and `Success` (boolean) properties.

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettranslatedlyricsbyvideoidandlanguage"></a>
# **GetTranslatedLyricsByVideoIdAndLanguage**
> TranslatedLyricsListResponse GetTranslatedLyricsByVideoIdAndLanguage (string videoId, string language)

Get Translated Lyrics by Video ID and Language

Fetches translated lyrics for a specific video ID and language code.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTranslatedLyricsByVideoIdAndLanguageExample
    {
        public void main()
        {
            var apiInstance = new TranslationsApi();
            var videoId = videoId_example;  // string | YouTube video ID
            var language = language_example;  // string | Language code (e.g., 'en', 'es', 'fr', 'de', 'ja')

            try
            {
                // Get Translated Lyrics by Video ID and Language
                TranslatedLyricsListResponse result = apiInstance.GetTranslatedLyricsByVideoIdAndLanguage(videoId, language);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TranslationsApi.GetTranslatedLyricsByVideoIdAndLanguage: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **videoId** | **string**| YouTube video ID | 
 **language** | **string**| Language code (e.g., &#x27;en&#x27;, &#x27;es&#x27;, &#x27;fr&#x27;, &#x27;de&#x27;, &#x27;ja&#x27;) | 

### Return type

[**TranslatedLyricsListResponse**](TranslatedLyricsListResponse.md)

**API Response Format:**
The actual API returns:
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
    }
  ],
  "success": true
}
```

The client deserializes this into a `TranslatedLyricsListResponse` with `Data` (array) and `Success` (boolean) properties.

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
