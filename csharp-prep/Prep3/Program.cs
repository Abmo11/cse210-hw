using System;

class Program
{
    static void Main(string[] args)
    {
        // Asks for a magic number and stores it in variable
        Console.Write("What is the magic number? ");
        string magicInput = Console.ReadLine();
        // Parses to integer
        int magicNumber = int.Parse(magicInput);

        // Variable for use in while loop
        int guess;

        // Compares input to guess using do while loop
        do
        {
            // Asks for a guess and stores it in variable
            Console.Write("What is your guess? ");
            string guessInput = Console.ReadLine();
            // Parses to integer
            guess = int.Parse(guessInput);
            
            // Compares guess to input
            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (guess != magicNumber);
    }
}