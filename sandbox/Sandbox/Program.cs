
using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // URL of the YouTube video
        string youtubeUrl = "https://www.youtube.com/watch?v=ZCdJtaL9V6E";

        try
        {
            // Open the URL in the default web browser
            Process.Start(new ProcessStartInfo
            {
                FileName = youtubeUrl,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            // Handle any exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
