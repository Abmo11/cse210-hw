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
        string display = $"There are {_songCount} songs in {_name}:";
        Console.WriteLine(display);

        int counter = 1;
        foreach (Song s in _songList)
        {
            Console.WriteLine($"{counter}. {s.DisplaySongInfo}");
        }
    }

    public void AddSongByArtist(Song song, string artist)
    {
        foreach (Song s in _songList)
        {
            if (song.GetArtist() == artist)
            {
                AddSong(song); // Uses AddSong method
            }
        }

    }
}