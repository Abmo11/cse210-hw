using System;
using System.Dynamic;

class Program
{
    static void Main(string[] args)
    {
        // Set to 1 / 1
        Fraction frac1 = new Fraction();
        // Set to arg / 1
        Fraction frac2 = new Fraction(5);
        // Set to arg / arg
        Fraction frac3 = new Fraction(3, 4);
        // Set to arg / arg
        Fraction frac4 = new Fraction(1, 3);

        Console.WriteLine(frac1.GetFractionString());
        Console.WriteLine(frac1.GetDecimalValue());

        Console.WriteLine(frac2.GetFractionString());
        Console.WriteLine(frac2.GetDecimalValue());

        Console.WriteLine(frac3.GetFractionString());
        Console.WriteLine(frac3.GetDecimalValue());

        Console.WriteLine(frac4.GetFractionString());
        Console.WriteLine(frac4.GetDecimalValue());
    }
}