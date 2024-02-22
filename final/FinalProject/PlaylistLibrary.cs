using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;


public class PlaylistLibrary
{
    // DECLARED MEMBER VARIABLES
    private List<Playlist> _listOfPlaylists; // Declares list variable
    private int _playListCount;

    // CONSTRUCTOR
    public PlaylistLibrary() // Initializes all member variables
    {
        _listOfPlaylists = new List<Playlist>(); // Initializes empty list of 'Song' objects
        _playListCount = 0;
    }

    //GETTER
    public int GetPlaylistCount()
    {
        return _playListCount;
    }

    // METHODS
    public void DisplayLibraryInfo() // Displays all playlists' info
    {
        Console.WriteLine($"You have {_playListCount} Playlists:");
        Console.WriteLine();

        int counter = 1;
        foreach (Playlist p in _listOfPlaylists)
        {
            string playlistType = GetPlaylistType(p);
            Console.WriteLine($"{counter}. {p.GetPlaylistName()} -- {p.GetSongCount()} songs Type: {playlistType}");
            counter++;
        }
    }

    public void NotTheMusicVault()
    {
        Console.WriteLine($"{_playListCount - 1} Playlists:");
        Console.WriteLine();

        // Starts from the second element
        int counter = 1;
        foreach (Playlist p in _listOfPlaylists.Skip(1))
        {
            string playlistType = GetPlaylistType(p);
            Console.WriteLine($"{counter}. {p.GetPlaylistName()} -- {p.GetSongCount()} songs -- Type: {playlistType}");
            counter++;
        }
    }


    private string GetPlaylistType(Playlist playlist)
    {
        // Determine the type of the playlist and return its name
        if (playlist is ArtistPlaylist)
        {
            return "Artist Playlist";
        }
        else if (playlist is ShufflePlaylist)
        {
            return "Shuffle Playlist";
        }
        else
        {
            return "Custom Playlist";
        }
    }

    public Playlist GetPlaylist(int index)
    {
        return _listOfPlaylists[index - 1]; // Returns specific Playlist chosen by user
    }

    public void AddPlaylist(Playlist playlist) // Adds playlist to playlist library
    {
        _listOfPlaylists.Add(playlist); // Add the provided playlist object to the list
        _playListCount++; // Increment the playlist count
    }


    public void RemovePlaylist(int index)
    {
        if (index >= 0 && index < _listOfPlaylists.Count)
        {
            _listOfPlaylists.RemoveAt(index);
            _playListCount--;
        }
        else
        {
            Console.WriteLine("Invalid index specified.");
        }
    }

}