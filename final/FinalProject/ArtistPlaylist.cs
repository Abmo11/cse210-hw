using System;

// Playlist that looks for a certain artist and makes a list of songs
// based on specified artist
public class ArtistPlaylist : Playlist
{
    // CONSTRUCTOR
    public ArtistPlaylist(string name) : base(name)
    {

    }

    // METHODS
    public override void DisplayDescription()
    {
        string display = $"There are {_songCount} songs in Playlist {_name}:";
        Console.WriteLine(display);
        Console.WriteLine();

        int counter = 1;
        foreach (Song s in _songList)
        {
            Console.WriteLine($"{counter}. {s.DisplaySongInfo()}");
            counter++;
        }
    }

    public void AddSongByArtist(List<Song> songs, string artist)
    {
        foreach (Song s in songs)
        {
            if (s.GetArtist() == artist)
            {
                AddSong(s); // Uses AddSong method
            }
        }

    }
}