using System;

// Playlist that looks for a certain artist and makes a list of songs
// based on specified artist
public class CustomPlaylist : Playlist
{
    // CONSTRUCTOR
    public CustomPlaylist(string name) : base(name)
    {

    }

    // METHODS
    public override void DisplayDescription()
    {
        string display = $"You picked {_songCount} songs for Playlist {_name}:";
        Console.WriteLine(display);
        Console.WriteLine();

        int counter = 1;
        foreach (Song s in _songList)
        {
            Console.WriteLine($"{counter}. {s.DisplaySongInfo()}");
            counter++;
        }
    }
}