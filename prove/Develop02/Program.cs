using System;

/********
EXCEEDING REQUIREMENTS:

I installed Newtonsoft.Json package to serialize and deserialize 
'Entry' objects to and from JSON files.

 ********/

class Program
{
    static void Main(string[] args)
    {
        // *** Creates new journal object ***
        Journal newJournal = new Journal();

        // Variable for user's choice in switch statement
        int iChoose = -1;

        DisplayWelcome();

        do
        {
            DisplayMenu();
            iChoose = choice();

            // *** Creates a new prompt object every iteration ***
            PromptGenerator newPrompt = new PromptGenerator();

            switch (iChoose)
            {
                case 1:
                    // *** Into new Entry object
                    // *** Creates a new entry object every time 1 is chosen ***
                    Entry newEntry = new Entry();
                    // Sets date in newEntry._date object
                    DateTime theCurrentTime = DateTime.Now;
                    newEntry._date = theCurrentTime.ToShortDateString();
                    //  Sets the prompt text = new prompt 
                    newEntry._promptText = newPrompt.GetRandomPrompt();
                    // Displays prompt, gets input and sets it to newEntry._entryText
                    makeNewEntry(newEntry);

                    // *** Into new Journal object
                    // Adds newEntry object to newJournal list using AddEntry method
                    newJournal.AddEntry(newEntry);
                    break;
                case 2:
                    // Displays all entries using newJournal's DisplayAll() method
                    newJournal.DisplayAll();
                    break;
                case 3:
                    loadFile(newJournal);
                    break;
                case 4:
                    writeFile(newJournal);
                    break;
                case 5:
                    break;
            }
        } while (iChoose != 5);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Journal program!");
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");

        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
    }

    static void makeNewEntry(Entry newEntry)
    {
        // Displays the prompt text to console
        Console.WriteLine(newEntry._promptText);
        // Asks for newEntry input
        Console.Write("> ");

        // Sets the input to newEntry._entryText
        newEntry._entryText = Console.ReadLine();
    }

    static int choice()
    {
        Console.Write("What would you like to do? ");
        int choice = int.Parse(Console.ReadLine());

        return choice;
    }

    static void writeFile(Journal newJournal)
    {
        Console.Write("What is the file name? ");
        string fileName = Console.ReadLine();

        newJournal.SaveToFile(fileName);
    }

    static void loadFile(Journal newJournal)
    {
        Console.Write("What is the file name? ");
        string fileName = Console.ReadLine();

        newJournal.LoadFromFile(fileName);
    }
}