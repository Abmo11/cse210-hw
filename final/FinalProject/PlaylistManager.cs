using System;
using System.Diagnostics.Metrics;
using System.IO;

public class PlaylistManager
{
    // MEMBER VARIABLES
    PlaylistLibrary _myPlaylistLibrary = new PlaylistLibrary();
    MusicVaultPlaylist _myMusicVault = new MusicVaultPlaylist("My Music Vault");

    // CONSTRUCTOR
    public PlaylistManager()
    {
        _myPlaylistLibrary.AddPlaylist(_myMusicVault);
    }

    // METHODS
    public void Run()  // "main" function for this class - called by Program.cs & runs menu loop
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Music Video Playlist Maker!");

        int iChoose = 0;
        do
        {
            DisplayStartMenu();
            iChoose = UserChoice();

            switch (iChoose)
            {
                case 1:
                    Console.WriteLine("Let's add a song to your Music Vault!");
                    _myMusicVault.AddSong(CreateSong());
                    Console.WriteLine("Your new song is now available in your Music Vault!");
                    break;
                case 2:
                    AddSongToPlaylist();
                    break;
                case 3:
                    RemoveSongFromPlaylist();
                    break;
                case 4:
                    ChoosePlaylistType();
                    CreatePlaylist();
                    Console.WriteLine("Your new Playlist has been added to your Playlist Library!");
                    break;
                case 5:
                    RemovePlaylist();
                    break;
                case 6:
                    ListPlaylistDetails();
                    Playlist playThis = ChooseToPlay();
                    playThis.DisplayDescription();
                    PlaySongsOnEnter(playThis);
                    break;
                case 7:
                    break;
            }
        } while (iChoose != 6);
    }

    private void DisplayStartMenu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("  1. Add a song to the Music Vault");
        Console.WriteLine("  2. Add a song to an existing Playlist");
        Console.WriteLine("  3. Remove a Song from a Playlist");
        Console.WriteLine("  4. Create a Playlist");
        Console.WriteLine("  5. Delete a Playlist");
        Console.WriteLine("  6. Play a Playlist");
        Console.WriteLine("  7. Quit");

    }

    private int UserChoice()
    {
        Console.Write("Please select a choice from the menu: ");
        int choice = int.Parse(Console.ReadLine());

        return choice;
    }

    private Song CreateSong()
    {
        Console.WriteLine();
        // Asks the user for info to create Song object
        Console.Write("What is the name of the song? ");
        string songName = Console.ReadLine();

        Console.Write("Who is the artist? ");
        string artistName = Console.ReadLine();

        Console.Write("Please provide the URL (web address) of the video: ");
        string videoUrl = Console.ReadLine();

        // Creates Song object with input data
        Song newSong = new Song(songName, artistName, videoUrl);

        return newSong;
    }

    private void AddSongToPlaylist()
    {
        Console.WriteLine();
        _myPlaylistLibrary.NotTheMusicVault();
        Console.WriteLine();
        Console.Write("(Enter 0 to return to main menu)");
        Console.Write("Choose a Playlist: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 0)
        {
            Run();
        }
        else
        {
            Playlist thisPlaylist = _myPlaylistLibrary.GetPlaylist(choice+1);

            Song newSong = CreateSong();

            // Program adds song to desired Playlist and also to Music Vault
            thisPlaylist.AddSong(newSong);
            _myMusicVault.AddSong(newSong);

            Console.WriteLine($"Your new song has been added to {thisPlaylist.GetPlaylistName()} & your Music Vault!");
        }
    }

    private void RemoveSongFromPlaylist()
    {
        ListPlaylistDetails(); // Lists out name and song count of each playlist

        Playlist thisPlaylist = ChooseToPlay(); // Returns specific Playlist chosen by user - saves to thisPlaylist

        List<Song> listSongs = thisPlaylist.GetSongs(); // Returns list of songs and saves to listSongs

        Console.WriteLine();
        int counter = 1;
        foreach (Song s in listSongs) // Lists out name and artist for each song
        {
            Console.WriteLine($"{counter}. {s.DisplaySongInfo()}");
            counter++;
        }

        Console.WriteLine();
        Console.Write("Which Song would you like to remove? ");
        int choice = int.Parse(Console.ReadLine()); //User choice/input
        string songInfo = listSongs[choice - 1].DisplaySongInfo();

        thisPlaylist.RemoveSong(choice - 1); // Removes song by index

        Console.WriteLine($"{songInfo} has been removed from {thisPlaylist.GetPlaylistName()}.");
    }

    private void RemovePlaylist()
    {
        ListPlaylistDetails(); // Lists out name and song count of each playlist

        Console.WriteLine();
        Console.Write("Which Playlist would you like to delete? ");
        int choice = int.Parse(Console.ReadLine()); //User choice/input
        string playlistInfo = _myPlaylistLibrary.GetPlaylist(choice - 1).GetPlaylistName();

        _myPlaylistLibrary.RemovePlaylist(choice - 1); // Removes playlist by index

        Console.WriteLine($"{playlistInfo} has been deleted.");
    }

    private void ListPlaylistDetails()
    {
        // Displays number of Playlists and short description of each
        _myPlaylistLibrary.DisplayLibraryInfo();
    }

    private void ChoosePlaylistType()
    {
        // Lists the types of Playlists
        Console.WriteLine("#1 & #2 will automatically populate from your Music Vault.");
        Console.WriteLine("#3 will be available for you to populate manually.");
        Console.WriteLine();
        Console.WriteLine("  1. Playlist by Artist");
        Console.WriteLine("  2. Shuffle Playlist");
        Console.WriteLine("  3. Custom Playlist");
    }

    private void CreatePlaylist()
    {
        // Asks the user for the information about a new playlist - creates playlist and adds it to Playlist Library
        Console.Write("Which type of Playlist would you like to create? ");
        int whichPlaylist = int.Parse(Console.ReadLine());

        Console.Write("What is the name of this Playlist? ");
        string listName = Console.ReadLine();

        List<Song> songs = _myMusicVault.GetSongs();

        switch (whichPlaylist)
        {
            case 1:
                ArtistPlaylist newArtistPlaylist = new ArtistPlaylist(listName);

                Console.Write("What is the name of the artist? ");
                string artist = Console.ReadLine();

                newArtistPlaylist.AddSongByArtist(songs, artist);

                _myPlaylistLibrary.AddPlaylist(newArtistPlaylist);
                break;
            case 2:
                ShufflePlaylist newShufflePlaylist = new ShufflePlaylist(listName);

                newShufflePlaylist.AddSongByShuffle(songs);

                _myPlaylistLibrary.AddPlaylist(newShufflePlaylist);
                break;
            case 3:
                CustomPlaylist newCustomPlaylist = new CustomPlaylist(listName);
                _myPlaylistLibrary.AddPlaylist(newCustomPlaylist);
                break;
        }
    }

    private Playlist ChooseToPlay() // Returns specific Playlist chosen by user
    {
        Console.WriteLine();
        Console.Write("Choose a Playlist: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 0)
        {
            return null; // Return null to signal returning to main menu
        }

        return _myPlaylistLibrary.GetPlaylist(choice);
    }

    private void PlaySongsOnEnter(Playlist pushPlay)
    {
        // Get the list of songs from the playlist
        var songs = pushPlay.GetSongs();

        // Initialize the index to keep track of the current song
        int currentIndex = 0;

        // Prompt the user to press Enter to play the next song
        Console.WriteLine("Press Enter to play the next song or any other key to exit...");

        // Loop until all songs are played
        while (true)
        {
            // Wait for the user to press a key
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // If 'Enter' is pressed
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                // If there are more songs in the playlist
                if (currentIndex < songs.Count)
                {
                    // Get current song
                    Song currentSong = songs[currentIndex];

                    // Displaying Song info
                    Console.WriteLine($"Now playing: {currentSong.DisplaySongInfo()}");

                    // Play current song
                    currentSong.LaunchVideo();

                    // Move to the next song
                    currentIndex++;
                }
                else
                {
                    // If there are no more songs in the playlist - call Run() again to restart the menu logic
                    Run();
                }
            }
            else
            {
                // If any other key is pressed - exit the loop by calling Run()
                Run();
            }
        }
    }
}