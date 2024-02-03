using System;

public class ListingActivity : Activity
{
    // Fields
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "What are personal strengths of yours?",
        "Who are some of your personal heroes?",
        "When have you felt the Holy Ghost this month?"
    };

    // Constructor
    public ListingActivity()
    {   // Sets inherited - protected - fields
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    // Methods
    public void Run()
    {
        DisplayStartingMessage();

        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine(GetRandomPrompt());

        // Timer
        Console.WriteLine("You may begin in: ");
        ShowCountDown(3);

        _count = GetListFromUser().Count;  // Executes function - returns list - counts items in list
        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        // The range is [0 - _prompts.count]
        int randPrompt = random.Next(_prompts.Count);

        string message = "List as many responses you can to the following prompt:";
        // Returns prompt at 'randprompt' index, after 'message'
        return $"{message} \n --- {_prompts[randPrompt]} --- ";
    }

    private List<string> GetListFromUser()
    {
        // List for user inputs
        List<string> userItems = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            // Asks for input
            Console.Write("> ");

            // Adds user input to userItems list
            userItems.Add(Console.ReadLine());
        }

        return userItems;
    }
}