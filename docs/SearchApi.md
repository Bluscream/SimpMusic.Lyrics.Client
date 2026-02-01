# IO.Swagger.Api.SearchApi

All URIs are relative to *https://api-lyrics.simpmusic.org*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SearchLyrics**](SearchApi.md#searchlyrics) | **GET** /v1/search | Search Lyrics
[**SearchLyricsByArtist**](SearchApi.md#searchlyricsbyartist) | **GET** /v1/search/artist | Search Lyrics by Artist
[**SearchLyricsByTitle**](SearchApi.md#searchlyricsbytitle) | **GET** /v1/search/title | Search Lyrics by Song Title

<a name="searchlyrics"></a>
# **SearchLyrics**
> LyricsListResponse SearchLyrics (string q, int? limit = null, int? offset = null)

Search Lyrics

Performs a general search across lyrics content with optional pagination using limit and offset parameters.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchLyricsExample
    {
        public void main()
        {
            var apiInstance = new SearchApi();
            var q = q_example;  // string | Search query string
            var limit = 56;  // int? | Maximum number of results to return (optional) 
            var offset = 56;  // int? | Number of results to skip (optional) 

            try
            {
                // Search Lyrics
                LyricsListResponse result = apiInstance.SearchLyrics(q, limit, offset);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SearchApi.SearchLyrics: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **q** | **string**| Search query string | 
 **limit** | **int?**| Maximum number of results to return | [optional] 
 **offset** | **int?**| Number of results to skip | [optional] 

### Return type

[**LyricsListResponse**](LyricsListResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="searchlyricsbyartist"></a>
# **SearchLyricsByArtist**
> LyricsListResponse SearchLyricsByArtist (string artist, int? limit = null, int? offset = null)

Search Lyrics by Artist

Searches for lyrics by artist name with optional pagination using limit and offset parameters.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchLyricsByArtistExample
    {
        public void main()
        {
            var apiInstance = new SearchApi();
            var artist = artist_example;  // string | Artist name to search for
            var limit = 56;  // int? | Maximum number of results to return (optional) 
            var offset = 56;  // int? | Number of results to skip (optional) 

            try
            {
                // Search Lyrics by Artist
                LyricsListResponse result = apiInstance.SearchLyricsByArtist(artist, limit, offset);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SearchApi.SearchLyricsByArtist: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **artist** | **string**| Artist name to search for | 
 **limit** | **int?**| Maximum number of results to return | [optional] 
 **offset** | **int?**| Number of results to skip | [optional] 

### Return type

[**LyricsListResponse**](LyricsListResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="searchlyricsbytitle"></a>
# **SearchLyricsByTitle**
> LyricsListResponse SearchLyricsByTitle (string title, int? limit = null, int? offset = null)

Search Lyrics by Song Title

Searches for lyrics by song title with optional pagination using limit and offset parameters.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchLyricsByTitleExample
    {
        public void main()
        {
            var apiInstance = new SearchApi();
            var title = title_example;  // string | Song title to search for
            var limit = 56;  // int? | Maximum number of results to return (optional) 
            var offset = 56;  // int? | Number of results to skip (optional) 

            try
            {
                // Search Lyrics by Song Title
                LyricsListResponse result = apiInstance.SearchLyricsByTitle(title, limit, offset);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SearchApi.SearchLyricsByTitle: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **title** | **string**| Song title to search for | 
 **limit** | **int?**| Maximum number of results to return | [optional] 
 **offset** | **int?**| Number of results to skip | [optional] 

### Return type

[**LyricsListResponse**](LyricsListResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
