using System;

class Program
{
    static void Main(string[] args)
    {
        // Asks user for their grade
        Console.Write("Please enter your grade: ");
        // Stores input in a string variable
        string userInput = Console.ReadLine();
        // Parses string input as int for later use
        int grade = int.Parse(userInput);

        // Place holder for letter grade to be assigned
        string letter;

        // Compares input to a grade & assigns letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";

        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Displays letter grade
        Console.WriteLine($"Your grade is: {letter}");

        // Checks to see if student passed; 70 or better
        // Displays a messeage 
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass. Please try again!");
        }
    }
}