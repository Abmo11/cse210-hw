using System;

// STRETCH CHALLENGE:

// I decided to save to and load from a JSON file using Newtonsoft.Json
// I installed Newtonsoft.Json package to serialize and deserialize objects
// I uploaded a JSON file to GitHub for proof that it works: 'goals.json'

class Program
{
    static void Main(string[] args)
    {
        GoalManager newGoalManager = new GoalManager();

        newGoalManager.Start();
    }
}