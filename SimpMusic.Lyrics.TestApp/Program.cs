using SimpMusic.Lyrics.Client.Api;
using SimpMusic.Lyrics.Client.Model;

namespace SimpMusic.Lyrics.TestApp;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("SimpMusic Lyrics API Test App");
        Console.WriteLine("==============================");
        Console.WriteLine();

        try
        {
            // Test Lyrics API
            await TestLyricsApi();

            // Test Search API
            await TestSearchApi();

            // Test Translations API
            await TestTranslationsApi();

            // Test Voting API (requires HMAC auth)
            await TestVotingApi();

            // Test Create endpoints (requires HMAC auth)
            await TestCreateEndpoints();

            Console.WriteLine("All tests completed!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }

    static async Task TestLyricsApi()
    {
        Console.WriteLine("Testing Lyrics API...");
        Console.WriteLine("---------------------");

        var lyricsApi = new LyricsApi();

        // Test GetLyricsByVideoId
        try
        {
            Console.WriteLine("1. Testing GetLyricsByVideoId with video ID: Y9SmNz2RofI");
            var lyrics = await lyricsApi.GetLyricsByVideoIdAsync("Y9SmNz2RofI");
            
            if (lyrics != null && !string.IsNullOrWhiteSpace(lyrics.SongTitle))
            {
                Console.WriteLine($"   ✓ Success! Found lyrics:");
                Console.WriteLine($"     - Song: {lyrics.SongTitle}");
                Console.WriteLine($"     - Artist: {lyrics.ArtistName ?? "(null)"}");
                Console.WriteLine($"     - PlainLyric length: {lyrics.PlainLyric?.Length ?? 0}");
                Console.WriteLine($"     - SyncedLyrics length: {lyrics.SyncedLyrics?.Length ?? 0}");
                Console.WriteLine($"     - RichSyncLyrics length: {lyrics.RichSyncLyrics?.Length ?? 0}");
            }
            else
            {
                Console.WriteLine("   ✗ No lyrics found");
            }
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx) when (apiEx.ErrorCode == 404)
        {
            Console.WriteLine("   ✗ Lyrics not found (404)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ✗ Error: {ex.GetType().Name}: {ex.Message}");
        }

        Console.WriteLine();
    }

    static async Task TestSearchApi()
    {
        Console.WriteLine("Testing Search API...");
        Console.WriteLine("---------------------");

        var searchApi = new SearchApi();

        // Test SearchLyrics
        try
        {
            Console.WriteLine("1. Testing SearchLyrics with query: 'demons'");
            var searchResults = await searchApi.SearchLyricsAsync("demons", limit: 3);
            
            if (searchResults != null && searchResults.Data != null && searchResults.Data.Count > 0)
            {
                Console.WriteLine($"   ✓ Success! Found {searchResults.Data.Count} result(s):");
                foreach (var result in searchResults.Data.Take(3))
                {
                    Console.WriteLine($"     - {result.SongTitle ?? "(null)"} by {result.ArtistName ?? "(null)"} (ID: {result.VideoId ?? "(null)"})");
                }
            }
            else
            {
                Console.WriteLine("   ✗ No results found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ✗ Error: {ex.Message}");
        }

        // Test SearchLyricsByTitle
        try
        {
            Console.WriteLine("2. Testing SearchLyricsByTitle with title: 'Demons'");
            var titleResults = await searchApi.SearchLyricsByTitleAsync("Demons", limit: 2);
            
            if (titleResults != null && titleResults.Data != null && titleResults.Data.Count > 0)
            {
                Console.WriteLine($"   ✓ Success! Found {titleResults.Data.Count} result(s):");
                foreach (var result in titleResults.Data.Take(2))
                {
                    Console.WriteLine($"     - {result.SongTitle ?? "(null)"} by {result.ArtistName ?? "(null)"} (ID: {result.VideoId ?? "(null)"})");
                }
            }
            else
            {
                Console.WriteLine("   ✗ No results found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ✗ Error: {ex.Message}");
        }

        // Test SearchLyricsByArtist
        try
        {
            Console.WriteLine("3. Testing SearchLyricsByArtist with artist: 'Imagine Dragons'");
            var artistResults = await searchApi.SearchLyricsByArtistAsync("Imagine Dragons", limit: 2);
            
            if (artistResults != null && artistResults.Data != null && artistResults.Data.Count > 0)
            {
                Console.WriteLine($"   ✓ Success! Found {artistResults.Data.Count} result(s):");
                foreach (var result in artistResults.Data.Take(2))
                {
                    Console.WriteLine($"     - {result.SongTitle ?? "(null)"} by {result.ArtistName ?? "(null)"} (ID: {result.VideoId ?? "(null)"})");
                }
            }
            else
            {
                Console.WriteLine("   ✗ No results found");
            }
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx) when (apiEx.ErrorCode == 404)
        {
            Console.WriteLine("   ✗ Endpoint not found (404) - may not be available");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ✗ Error: {ex.GetType().Name}: {ex.Message}");
        }

        Console.WriteLine();
    }

    static async Task TestTranslationsApi()
    {
        Console.WriteLine("Testing Translations API...");
        Console.WriteLine("----------------------------");

        var translationsApi = new TranslationsApi();

        // Test GetTranslatedLyricsByVideoId
        try
        {
            Console.WriteLine("1. Testing GetTranslatedLyricsByVideoId with video ID: Y9SmNz2RofI");
            var translations = await translationsApi.GetTranslatedLyricsByVideoIdAsync("Y9SmNz2RofI");
            
            if (translations != null && translations.Data != null && translations.Data.Count > 0)
            {
                Console.WriteLine($"   ✓ Success! Found {translations.Data.Count} translation(s):");
                foreach (var translation in translations.Data.Take(3))
                {
                    Console.WriteLine($"     - Language: {translation.Language ?? "(null)"}, Length: {translation._TranslatedLyric?.Length ?? 0}");
                }
            }
            else
            {
                Console.WriteLine("   ✗ No translations found (this is normal if no translations exist)");
            }
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx) when (apiEx.ErrorCode == 404)
        {
            Console.WriteLine("   ✗ No translations found (404) - this is normal if no translations exist");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ✗ Error: {ex.GetType().Name}: {ex.Message}");
        }

        // Test GetTranslatedLyricsByVideoIdAndLanguage
        try
        {
            Console.WriteLine("2. Testing GetTranslatedLyricsByVideoIdAndLanguage with video ID: Y9SmNz2RofI, language: 'en'");
            var translation = await translationsApi.GetTranslatedLyricsByVideoIdAndLanguageAsync("Y9SmNz2RofI", "en");
            
            if (translation != null && translation.Data != null && translation.Data.Count > 0)
            {
                Console.WriteLine($"   ✓ Success! Found {translation.Data.Count} translation(s) in English:");
                foreach (var trans in translation.Data.Take(2))
                {
                    Console.WriteLine($"     - Language: {trans.Language ?? "(null)"}, Length: {trans._TranslatedLyric?.Length ?? 0}");
                }
            }
            else
            {
                Console.WriteLine("   ✗ No translations found for this language (this is normal if no translations exist)");
            }
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx) when (apiEx.ErrorCode == 404 || apiEx.ErrorCode == 500)
        {
            Console.WriteLine($"   ✗ No translations found ({apiEx.ErrorCode}) - this is normal if no translations exist");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ✗ Error: {ex.GetType().Name}: {ex.Message}");
        }

        Console.WriteLine();
    }

    static async Task TestVotingApi()
    {
        Console.WriteLine("Testing Voting API...");
        Console.WriteLine("---------------------");

        var votingApi = new VotingApi();

        // Test VoteForLyric
        try
        {
            Console.WriteLine("1. Testing VoteForLyric with lyric ID: 6882d066000aeeecd72f");
            var voteRequest = new VoteRequest("6882d066000aeeecd72f");
            var voteResult = await votingApi.VoteForLyricAsync(voteRequest);
            
            if (voteResult != null)
            {
                Console.WriteLine($"   ✓ Success! Vote submitted: {voteResult.Success}");
            }
            else
            {
                Console.WriteLine("   ✗ No response received");
            }
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx) when (apiEx.ErrorCode == 401 || apiEx.ErrorCode == 403)
        {
            Console.WriteLine($"   ✗ Authentication required ({apiEx.ErrorCode}) - Expected without HMAC auth");
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx)
        {
            Console.WriteLine($"   ✗ API Error ({apiEx.ErrorCode}): {apiEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ✗ Error: {ex.GetType().Name}: {ex.Message}");
        }

        // Test VoteForTranslatedLyric
        try
        {
            Console.WriteLine("2. Testing VoteForTranslatedLyric with translated lyric ID: test-id");
            var voteRequest = new VoteRequest("test-id");
            var voteResult = await votingApi.VoteForTranslatedLyricAsync(voteRequest);
            
            if (voteResult != null)
            {
                Console.WriteLine($"   ✓ Success! Vote submitted: {voteResult.Success}");
            }
            else
            {
                Console.WriteLine("   ✗ No response received");
            }
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx) when (apiEx.ErrorCode == 401 || apiEx.ErrorCode == 403)
        {
            Console.WriteLine($"   ✗ Authentication required ({apiEx.ErrorCode}) - Expected without HMAC auth");
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx)
        {
            Console.WriteLine($"   ✗ API Error ({apiEx.ErrorCode}): {apiEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ✗ Error: {ex.GetType().Name}: {ex.Message}");
        }

        Console.WriteLine();
    }

    static async Task TestCreateEndpoints()
    {
        Console.WriteLine("Testing Create Endpoints...");
        Console.WriteLine("----------------------------");

        var lyricsApi = new LyricsApi();
        var translationsApi = new TranslationsApi();

        // Test CreateLyric
        try
        {
            Console.WriteLine("1. Testing CreateLyric");
            var createRequest = new CreateLyricRequest(
                videoId: "TEST123",
                songTitle: "Test Song",
                artistName: "Test Artist",
                albumName: "Test Album",
                durationSeconds: 180,
                plainLyric: "Test lyrics\nLine 2\nLine 3",
                syncedLyrics: "[00:00.00]Test lyrics\n[00:05.00]Line 2\n[00:10.00]Line 3",
                richSyncLyrics: null,
                vote: 0,
                contributor: "TestApp",
                contributorEmail: "test@example.com"
            );
            
            var createResult = await lyricsApi.CreateLyricAsync(createRequest);
            
            if (createResult != null && createResult.Data != null)
            {
                Console.WriteLine($"   ✓ Success! Created lyric with ID: {createResult.Data.Id ?? "(null)"}");
            }
            else
            {
                Console.WriteLine("   ✗ No response received");
            }
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx) when (apiEx.ErrorCode == 401 || apiEx.ErrorCode == 403)
        {
            Console.WriteLine($"   ✗ Authentication required ({apiEx.ErrorCode}) - Expected without HMAC auth");
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx)
        {
            Console.WriteLine($"   ✗ API Error ({apiEx.ErrorCode}): {apiEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ✗ Error: {ex.GetType().Name}: {ex.Message}");
        }

        // Test CreateTranslatedLyric
        try
        {
            Console.WriteLine("2. Testing CreateTranslatedLyric");
            var createTranslatedRequest = new CreateTranslatedLyricRequest(
                videoId: "TEST123",
                translatedLyric: "Test translated lyrics\nLine 2\nLine 3",
                language: "es",
                vote: 0,
                contributor: "TestApp",
                contributorEmail: "test@example.com"
            );
            
            var createTranslatedResult = await translationsApi.CreateTranslatedLyricAsync(createTranslatedRequest);
            
            if (createTranslatedResult != null && createTranslatedResult.Data != null)
            {
                Console.WriteLine($"   ✓ Success! Created translation with ID: {createTranslatedResult.Data.Id ?? "(null)"}");
            }
            else
            {
                Console.WriteLine("   ✗ No response received");
            }
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx) when (apiEx.ErrorCode == 401 || apiEx.ErrorCode == 403)
        {
            Console.WriteLine($"   ✗ Authentication required ({apiEx.ErrorCode}) - Expected without HMAC auth");
        }
        catch (SimpMusic.Lyrics.Client.ApiException apiEx)
        {
            Console.WriteLine($"   ✗ API Error ({apiEx.ErrorCode}): {apiEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ✗ Error: {ex.GetType().Name}: {ex.Message}");
        }

        Console.WriteLine();
    }
}
