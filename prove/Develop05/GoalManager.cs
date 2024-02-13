using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


public class GoalManager
{
    // Member Variables
    private List<Goal> _goals; // Declares list variable
    protected int _score;

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>(); // Initializes empty list of 'Goals'
        _score = 0;
    }

    // Methods
    public void Start()
    {
        Console.Clear();
        // This is the "main" function for this class. It is called by Program.cs, and then runs the menu loop
        int iChoose = 0;
        do
        {
            DisplayPlayerInfo();
            DisplayStartMenu();
            iChoose = Choose();

            switch (iChoose)
            {
                case 1:
                    ChooseGoalNames();
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    ListGoalNames();
                    RecordEvent();
                    break;
                case 6:
                    break;
            }
        } while (iChoose != 6);
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine();
        // Displays the players current score
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();
    }

    private void DisplayStartMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. Quit");
    }

    private int Choose()
    {
        Console.Write("Select a choice from the menu: ");
        int choice = int.Parse(Console.ReadLine());

        return choice;
    }

    private void ChooseGoalNames()
    {
        // Lists the names of each of the goals
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
    }

    private void ListGoalDetails()
    {
        int counter = 1;
        Console.WriteLine("The goals are:");

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{counter}. {goal.GetDetailsString()}");

            counter++;
        }
    }

    private void CreateGoal()
    {
        // Asks the user for the information about a new goal.Then, creates the goal and adds it to the list
        Console.Write("Which type of goal would you like to create? ");
        int whichGoal = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string goalDescription = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int goalPoints = int.Parse(Console.ReadLine());

        switch (whichGoal)
        {
            case 1:
                SimpleGoal newSimple = new SimpleGoal(goalName, goalDescription, goalPoints);
                _goals.Add(newSimple);
                break;
            case 2:
                EternalGoal newEternal = new EternalGoal(goalName, goalDescription, goalPoints);
                _goals.Add(newEternal);
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int goalTarget = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int goalBonus = int.Parse(Console.ReadLine());

                ChecklistGoal newCheck = new ChecklistGoal(goalName, goalDescription, goalPoints, goalTarget, goalBonus);
                _goals.Add(newCheck);
                break;
        }
    }

    private void RecordEvent()
    {
        // Asks the user which goal they have done and then records the event by calling the RecordEvent method on that goal.
        // Asks the user which goal they have accomplished
        Console.Write("Which goal did you accomplish? ");

        // Reads the user input representing the index of the accomplished goal
        int goalNumber = int.Parse(Console.ReadLine());

        // Retrieves the goal corresponding to the user input index from the list of goals
        Goal goal = _goals[goalNumber - 1];

        // Records the event of accomplishing the goal by calling the RecordEvent method on the selected goal
        goal.RecordEvent();

        // Increases the score by the points earned from the accomplished goal
        _score += goal.GetPoints();
    }

    private void ListGoalNames()
    {
        int counter = 1;
        Console.WriteLine("The goals are:");

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{counter}. {goal.GetShortName()}");
            counter++;
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        // Create or overwrite the file using StreamWriter
        using (StreamWriter writer = new StreamWriter(file))
        {
            // Add _score at the top of the JSON file
            writer.WriteLine($"{{\n  \"Score\": {_score},\n  \"Goals\": [");

            // Iterate through each goal
            for (int i = 0; i < _goals.Count; i++)
            {
                // Get the string representation of the goal
                string goalString = _goals[i].GetStringRepresentation();

                // Write the string representation to the file
                writer.WriteLine(goalString + (i < _goals.Count - 1 ? "," : ""));
            }

            // Close the JSON array and object
            writer.WriteLine("]}");
        }
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        // Open the file for reading
        using (StreamReader inputFile = new StreamReader(file))
        {
            // Read the entire file contents
            string jsonContent = inputFile.ReadToEnd();

            // Deserialize the JSON content into an object
            dynamic data = JsonConvert.DeserializeObject(jsonContent);

            // Extract the score from the data
            _score = data.Score;

            // Extract the goals from the data
            dynamic goalsData = data.Goals;
            foreach (dynamic goalData in goalsData)
            {
                // Deserialize the goal from the string representation
                Goal goal = null;
                switch ((string)goalData.Type)
                {
                    case "Simple":
                        goal = new SimpleGoal((string)goalData.Name, (string)goalData.Description, (int)goalData.Points, (bool)goalData.IsComplete);
                        break;
                    case "Eternal":
                        goal = new EternalGoal((string)goalData.Name, (string)goalData.Description, (int)goalData.Points);
                        break;
                    case "Checklist":
                        goal = new ChecklistGoal((string)goalData.Name, (string)goalData.Description, (int)goalData.Points, (int)goalData.Target, (int)goalData.Bonus, (int)goalData.AmountCompleted);
                        break;
                }

                // Add the goal to the list
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
    }
}
