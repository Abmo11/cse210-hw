using System;
using System.Diagnostics;

public class Song
{
    // DECLARED MEMBER VARIABLES
    private string _name;
    private string _artist;
    private string _youTubeLink;

    // CONSTRUCTOR
    public Song(string name, string artist, string link) // Initializes member variables
    {
        _name = name;
        _artist = artist;
        _youTubeLink = link;
    }

    // GETTER
    public string GetArtist()
    {
        return _artist;
    }

    // METHODS
    public string DisplaySongInfo() // Displays song info
    {
        string info = $"{_name} by {_artist}";
        return info;
    }

    public void LaunchVideo() // Launches YouTube video using browser
    {
        try
        {
            // Open the URL in the default web browser
            Process.Start(new ProcessStartInfo
            {
                FileName = _youTubeLink,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            // Handle any exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
            // ex.Message retrieves the error message associated with the exception.
            // Describes the cause of the exception.
        }
    }
}