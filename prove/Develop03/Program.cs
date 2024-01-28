using System;

// Stretch Challenge:
// Modified Scripture class to load from a JSON file using Newtonsoft.Json
// I uploaded a JSON file to GitHub: 'scriptureData.json' for use w/this program

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter a file to load: ");
        Scripture newScripture = new Scripture(Console.ReadLine());

        while (true)
        {
            Console.Clear(); // Clear the console screen

            Console.WriteLine(newScripture.GetDisplayText());

            Console.WriteLine("Press enter to continue or type 'quit to finish:");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "quit" || newScripture.IsCompletelyHidden())
            {
                break; // exit the loop if the user types 'quit' or scripture is completely hidden
            }

            newScripture.HideRandomWords(3);
        }
    }

}