using System;

// Playlist program:
// Creates Playlists with songs from user input.
// Songs require a URL of your song, pressing enter will launch your song from your browser.
// Has a main 'Music Vault' that stores all songs.
// Uses 3 different Playlist types:
// Artist: searches 'Music Vault' for specified artist and automatically populates a playlist.
// Shuffle: randomly selects 10 songs from your 'Music Vault' to populate a playlist.
// Custom: Allows you to create your own playlist using the 'Add a song to an existing Playlist' menu choice.

class Program
{
    static void Main(string[] args)
    {
        PlaylistManager newPlaylistManager = new PlaylistManager();

        newPlaylistManager.Run();
    }
}