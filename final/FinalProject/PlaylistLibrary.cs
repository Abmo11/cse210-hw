using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;


public class PlaylistLibrary
{
    // DECLARED MEMBER VARIABLES
    private string _name;
    private List<Playlist> _listOfPlaylists; // Declares list variable
    private int _playListCount;

    // CONSTRUCTOR
    public PlaylistLibrary() // Initializes all member variables
    {
        _name = "Playlist Library";
        _listOfPlaylists = new List<Playlist>(); // Initializes empty list of 'Song' objects
        _playListCount = 0;
    }

    // METHODS
    public void DisplayLibraryInfo() // Displays all playlists' info
    {
        Console.WriteLine($"You have {_playListCount} Playlists:");

        int counter = 1;
        foreach (Playlist p in _listOfPlaylists)
        {
            Console.WriteLine($"{counter}. {p.GetPlaylistName()} -- {p.GetSongCount()}");
        }
    }

    public void AddPlaylist(Playlist playlist) // Adds playlist to playlist library
    {
        _listOfPlaylists.Add(playlist); // Add the provided playlist object to the list
        _playListCount++; // Increment the playlist count
    }


    public void RemovePlaylist() // Removes playlist from playlist library
    {

    }

}