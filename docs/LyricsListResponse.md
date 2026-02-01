# IO.Swagger.Model.LyricsListResponse
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Data** | [**List&lt;LyricsResponse&gt;**](LyricsResponse.md) | Array of lyric entries | 
**Success** | **bool?** | Indicates if the request was successful | 

## API Response Format

The actual API response includes an additional `type` field:

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

The `type` field is ignored during deserialization. Only `data` and `success` are mapped to the `LyricsListResponse` model.

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
