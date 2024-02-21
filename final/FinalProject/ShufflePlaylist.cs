using System;

// Playlist that randomly chooses songs from list of total songs
public class ShufflePlaylist : Playlist
{
    // CONSTRUCTOR
    public ShufflePlaylist(string name) : base(name)
    {

    }

    // METHODS
    public override void DisplayDescription()
    {
        string display = $"There are 10 shuffled songs in {_name}:";
        Console.WriteLine(display);

        int counter = 1;
        foreach (Song s in _songList)
        {
            Console.WriteLine($"{counter}. {s.DisplaySongInfo()}");
        }
    }

    public void AddSongByShuffle(List<Song> songs)
    {
        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            // The range is 0 inclusive - _songList.count exclusive
            int randIndex = random.Next(songs.Count);
            AddSong(songs[randIndex]);  // Uses AddSong method
        }
    }

}