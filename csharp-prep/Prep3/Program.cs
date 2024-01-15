using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the number guessing game!");

        // Creates a random number
        Random randNumber = new Random();
        int magicNumber = randNumber.Next(1, 101);

        // Variables for use in while loop
        int guess;
        int countTimes = 0;

        // Compares random number to guess using do while loop
        do
        {
            // Asks for a guess and stores it in variable
            Console.Write("What is your guess? ");
            string guessInput = Console.ReadLine();
            // Parses to integer
            guess = int.Parse(guessInput);

            // Compares guess to input
            // Counts number of guesses
            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
                countTimes++;
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
                countTimes++;
            }
            else
            {
                countTimes++;
                Console.WriteLine();
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {countTimes} guesses.");
            }
        } while (guess != magicNumber);
    }
}