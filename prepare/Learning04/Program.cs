using System;
using System.Security.AccessControl;

class Program
{
    static void Main(string[] args)
    {
        Assignment newAssignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(newAssignment.GetSummary());

        MathAssignment newMathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(newMathAssignment.GetSummary());
        Console.WriteLine(newMathAssignment.GetHomeworkList());

        WritingAssignment newWritingAssignment = new WritingAssignment("Jean Louise", "English Literature", "To Kill a Mockingbird");
        Console.WriteLine(newWritingAssignment.GetSummary());
        Console.WriteLine(newWritingAssignment.GetWritingInformation());
    }
}