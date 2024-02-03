using System;
using System.Collections.Generic; // Inherited to derived classes
using System.Threading;           // Inherited to derived classes


public class Activity
{
    // Fields
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructor
    protected Activity() // Sets fields to empty - ready for derived classes
    {
        _name = " ";
        _description = " ";
        _duration = 0;

    }

    // Methods
    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get Ready...");
    }
    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }
    protected void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>
        {
            // List is blueprint for illusion of spinner
            "|", "/", "-", "\\", "|", "/", "-", "\\"
        };

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime) // As long as current time is under end time
        {
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= spinner.Count)
            {
                i = 0;
            }
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);       // Write each number grater than 0
            // Console.Write(.);    // Writes "..." in i seconds
            Thread.Sleep(1000);     // This takes milliseconds
            // Back arrow, space, back arrow - writes on top of output
            // Double digits - 2 back arrows & 2 spaces
            Console.Write("\b \b");
        }
    }
}