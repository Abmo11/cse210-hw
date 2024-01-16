using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int    favNum   = PromptUserNumber();
        int    square   = SquareNumber(favNum);

        DisplayResult(userName, square);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favNumber = int.Parse(Console.ReadLine());

        return favNumber;
    }

    static int SquareNumber(int number)
    {
        int squaredNumber = number * number;

        return squaredNumber;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
} 