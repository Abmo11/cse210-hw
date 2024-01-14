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

        // Compares input to a grade and writes letter grade to console
        if (grade >= 90)
        {
            Console.WriteLine("Your letter grade is: A");
        }
        else if (grade >= 80)
        {
            Console.WriteLine("Your letter grade is: B");
        }
        else if (grade >= 70)
        {
            Console.WriteLine("Your letter grade is: C");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("Your letter grade is: D");
        }
        else
        {
            Console.WriteLine("Your letter grade is: F");
        }

        // Checks to see if student passed, 70 or better
        // Displays a messeage to console
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