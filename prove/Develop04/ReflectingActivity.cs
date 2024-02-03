using System;

public class ReflectingActivity : Activity
{
    // Fields
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you did something really difficult.",
        "Think of a time when you did something truly selfless",
        "Think of a time when you helped someone in need."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Constructor 
    public ReflectingActivity()
    {   // Sets inherited - protected - fields
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    // Methods
    public void Run()
    {
        DisplayStartingMessage();

        ShowSpinner(3);

        DisplayPrompt();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine(); // Waits for user to press 'enter' key
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");

        // Timer
        Console.Write("You may begin in: ");
        ShowCountDown(3);
        Console.Clear();

        // Iterates through questions
        DisplayQuestions();

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        // The range is [0 - _prompts.count]
        int randPrompt = random.Next(_prompts.Count);
        // Returns question at 'randprompt' index
        return _prompts[randPrompt];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        // The range is [0 - _prompts.count]
        int randPrompt = random.Next(_questions.Count);
        // Returns question at 'randprompt' index
        return _questions[randPrompt];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine();
        string message = "Consider the following prompt:";
        // Returns prompt at 'randprompt' index, after 'message' displays
        // uses 'new line' \n
        Console.WriteLine($"{message} \n\n --- {GetRandomPrompt()} --- ");
    }

    private void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"> {GetRandomQuestion()}");
            ShowSpinner(5);
        }
    }
}