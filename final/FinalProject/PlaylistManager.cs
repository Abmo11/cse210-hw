using System;
using System.IO;

public class PlaylistManager
{
    // MEMBER VARIABLES
    PlaylistLibrary _myPlaylistLibrary = new PlaylistLibrary();

    // CONSTRUCTOR
    public PlaylistManager()
    {

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
                    break;
                case 2:
                    break;
                case 3:
                    ChoosePlaylistType();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
        } while (iChoose != 6);
    }

    private void DisplayStartMenu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("  1. Add a song to the Music Vault");
        Console.WriteLine("  2. Add a song to an existing playlist");
        Console.WriteLine("  3. Create a playlist");
        Console.WriteLine("  4. Play a playlist");
        Console.WriteLine("  5. Save playlists");
        Console.WriteLine("  6. Load Playlists");
        Console.WriteLine("  7. Quit");

    }

    private int UserChoice()
    {
        Console.Write("Please select a choice from the menu: ");
        int choice = int.Parse(Console.ReadLine());

        return choice;
    }

    private void CreateSong()
    {
        // Asks the user for info to create Song object
        Console.Write("What is the name of the song? ");
        string songName = Console.ReadLine();

        Console.Write("Who is the artist? ");
        string artistName = Console.ReadLine();

        Console.Write("Please provide the URL (web address) of the video: ");
        string videoUrl = Console.ReadLine();

        // Creates Song object with input data
        Song newSong = new Song(songName, artistName, videoUrl);
    }

    private void ListPlaylistDetails()
    {
        // Displays number of Playlists and short description of each
        _myPlaylistLibrary.DisplayLibraryInfo();
    }

    private void ChoosePlaylistType()
    {
        // Lists the types of Playlists
        Console.WriteLine("The types of Playlists are:");
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

        switch (whichPlaylist)
        {
            case 1:
                ArtistPlaylist newArtistPlaylist = new ArtistPlaylist(listName);
                _myPlaylistLibrary.AddPlaylist(newArtistPlaylist);
                break;
            case 2:
                ShufflePlaylist newShufflePlaylist = new ShufflePlaylist(listName);
                _myPlaylistLibrary.AddPlaylist(newShufflePlaylist);
                break;
            case 3:
                break;
        }
    }

    private void SavePlaylists()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        // Create or overwrite the file using StreamWriter
        using (StreamWriter writer = new StreamWriter(file))
        {

        }
    }

    private void LoadPlaylists()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        // Open the file for reading
        using (StreamReader inputFile = new StreamReader(file))
        {

        }
    }
}
