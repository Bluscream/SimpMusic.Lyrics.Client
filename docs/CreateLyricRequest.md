# SimpMusic.Lyrics.Client.Model.CreateLyricRequest
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**VideoId** | **string** | YouTube video ID | 
**SongTitle** | **string** | Title of the song | 
**ArtistName** | **string** | Name of the artist | 
**AlbumName** | **string** | Name of the album (optional) | [optional] 
**DurationSeconds** | **int?** | Duration of the song in seconds | [optional] 
**PlainLyric** | **string** | Plain text lyrics without timing information | [optional] 
**SyncedLyrics** | **string** | Synced lyrics in LRC format with line-level timing | [optional] 
**RichSyncLyrics** | **string** | Rich synced lyrics with word-level timing | [optional] 
**Vote** | **int?** | Initial vote count (defaults to 0) | [optional] 
**Contributor** | **string** | Name of the contributor | [optional] 
**ContributorEmail** | **string** | Email of the contributor | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

