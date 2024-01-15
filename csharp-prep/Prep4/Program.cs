using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Instructions
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        // Creates new list called numbers
        List<int> numbers = new List<int>();
        // Variables for use in do while loop
        int listNumber = -1;
        int counter = 0;
        float totalNumber = 0;

        // Checks for 0 to end loop
        // Logic for total and average
        while (listNumber != 0)
        {
            Console.Write("Enter number: ");
            listNumber = int.Parse(Console.ReadLine());

            if (listNumber != 0)
            {
                numbers.Add(listNumber);
                totalNumber += listNumber;
                counter++;
            }
        }

        float average = totalNumber / counter;

        Console.WriteLine($"The sum is: {totalNumber}");
        Console.WriteLine($"The average is: {average}");


        // Initialize the variable 'max' with the first element of the 'numbers; list
        int max = numbers[0];

        // Iterate through each element in the 'numbers' list using a foreach loop
        foreach (int number in numbers)
        {
            // Check if the current 'number' is greater than the current maximum (max)
            if (number > max)
            {
                // If the current 'number' is greater, update the 'max' to be equal to the current 'number'
                // 'max' will eventually contain the largest number in the 'numbers' list
                max = number;
            }
            // Continue to the next iteration of the loop.
        }

        // At this point, 'max' contains the largest number in the 'numbers' list
        // Write max number to console
        Console.WriteLine($"The largest number is {max}");

        /* Test for input
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.Write(numbers[i]);
        }
        */

    }
}