using System;

public class BreathingActivity : Activity
{
    // Constructor
    public BreathingActivity()
    {   // Sets inherited - protected - fields
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    // Method
    public void Run()
    {
        DisplayStartingMessage();

        ShowSpinner(3);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine("Breathe in...");
            ShowCountDown(4);

            // Check elapsed time
            TimeSpan elapsedTime = DateTime.Now - startTime;
            // 
            if (elapsedTime.TotalSeconds >= _duration)
            {
                break; // Exit the loop
            }

            Console.WriteLine("Breathe out...");
            ShowCountDown(4);
        }

        DisplayEndingMessage();
    }
}