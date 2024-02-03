using System;

/********

EXCEEDING REQUIREMENTS:

Program keeps count of each activity the user has chosen.

 ********/

class Program
{
    static void Main(string[] args)
    {

        int breathingActivityCount = 0;
        int reflectingActivityCount = 0;
        int listingActivityCount = 0;

        // Variable for user's choice in switch statement
        int iChoose = -1;

        do
        {
            DisplayMenu();
            ActivityCount(breathingActivityCount, reflectingActivityCount, listingActivityCount);
            iChoose = Choice();

            switch (iChoose)
            {
                case 1:
                    breathingActivityCount++;
                    BreathingActivity newBreathingActivity = new BreathingActivity();
                    newBreathingActivity.Run();
                    break;
                case 2:
                    reflectingActivityCount++;
                    ReflectingActivity newReflectingActivity = new ReflectingActivity();
                    newReflectingActivity.Run();
                    break;
                case 3:
                    listingActivityCount++;
                    ListingActivity newListingActivity = new ListingActivity();
                    newListingActivity.Run();
                    break;
                case 4:
                    break;
            }
        } while (iChoose != 4);
    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");

        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Quit");
    }

    static void ActivityCount(int breathing, int reflecting, int listing)
    {
        Console.WriteLine("===============================");
        Console.WriteLine($"Breathing Activity Count:   {breathing}");
        Console.WriteLine($"Reflecting Activity Count:  {reflecting}");
        Console.WriteLine($"Listing Activity Count:     {listing}");
        Console.WriteLine("===============================");

    }

    static int Choice()
    {
        Console.Write("Select a choice from the menu: ");
        int choice = int.Parse(Console.ReadLine());

        return choice;
    }
}