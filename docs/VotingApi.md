# IO.Swagger.Api.VotingApi

All URIs are relative to *https://api-lyrics.simpmusic.org*

Method | HTTP request | Description
------------- | ------------- | -------------
[**VoteForLyric**](VotingApi.md#voteforlyric) | **POST** /v1/vote | Vote for Lyric
[**VoteForTranslatedLyric**](VotingApi.md#votefortranslatedlyric) | **POST** /v1/translated/vote | Vote for Translated Lyric

<a name="voteforlyric"></a>
# **VoteForLyric**
> SuccessResponse VoteForLyric (VoteRequest body)

Vote for Lyric

Submits a vote for a lyric entry. Requires HMAC authentication.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class VoteForLyricExample
    {
        public void main()
        {
            // Configure API key authorization: hmacAuth
            Configuration.Default.AddApiKey("X-HMAC", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-HMAC", "Bearer");

            var apiInstance = new VotingApi();
            var body = new VoteRequest(); // VoteRequest | 

            try
            {
                // Vote for Lyric
                SuccessResponse result = apiInstance.VoteForLyric(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VotingApi.VoteForLyric: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**VoteRequest**](VoteRequest.md)|  | 

### Return type

[**SuccessResponse**](SuccessResponse.md)

### Authorization

[hmacAuth](../README.md#hmacAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="votefortranslatedlyric"></a>
# **VoteForTranslatedLyric**
> SuccessResponse VoteForTranslatedLyric (VoteRequest body)

Vote for Translated Lyric

Submits a vote for a translated lyric entry. Requires HMAC authentication.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class VoteForTranslatedLyricExample
    {
        public void main()
        {
            // Configure API key authorization: hmacAuth
            Configuration.Default.AddApiKey("X-HMAC", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-HMAC", "Bearer");

            var apiInstance = new VotingApi();
            var body = new VoteRequest(); // VoteRequest | 

            try
            {
                // Vote for Translated Lyric
                SuccessResponse result = apiInstance.VoteForTranslatedLyric(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VotingApi.VoteForTranslatedLyric: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**VoteRequest**](VoteRequest.md)|  | 

### Return type

[**SuccessResponse**](SuccessResponse.md)

### Authorization

[hmacAuth](../README.md#hmacAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
