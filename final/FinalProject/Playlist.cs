using System;
using System.Collections.Generic;

public abstract class Playlist
{
    // MEMBER VARIABLES
    protected string _name;
    protected List<Song> _songList; // Declares list variable
    protected int _songCount = 0;

    // CONSTRUCTOR
    public Playlist(string name)
    {
        _name = name;
        _songList = new List<Song>(); // Initializes empty list of 'Song' objects
    }

    // GETTER
    public string GetPlaylistName()
    {
        return _name;
    }

    public int GetSongCount()
    {
        return _songCount;
    }

    // METHODS
    public abstract void DisplayDescription();

    public void AddSong(Song song) // Make abstract?
    {
        _songList.Add(song);
        _songCount++;
    }

    public void RemoveSong(int index)
    {
        if (index >= 0 && index < _songList.Count)
        {
            _songList.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }

        // Decreases song count by 1
        _songCount--;
    }
}