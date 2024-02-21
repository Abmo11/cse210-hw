using System;

public class MusicVaultPlaylist : Playlist
{
    // CONSTRUCTOR
    public MusicVaultPlaylist(string name) : base(name)
    {

    }

    // METHODS
    public override void DisplayDescription()
    {
        string display = $"You have {_songCount} total songs:";
        Console.WriteLine(display);

        int counter = 1;
        foreach (Song s in _songList)
        {
            Console.WriteLine($"{counter}. {s.DisplaySongInfo()}");
        }
    }
    
}