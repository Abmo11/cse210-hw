using System;
using Newtonsoft.Json;

public class SimpleGoal : Goal
{
    // Member Variable
    private bool _isComplete;

    // Constructor
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    // For use in deserializing JSON file
    public SimpleGoal(string name, string description, int points, bool IsComplete) : base(name, description, points)
    {
        _isComplete = IsComplete;
    }

    // Overridden Methods
    public override void RecordEvent()
    {
        _isComplete = true;

        Console.WriteLine($"Congratulations! You have earned {_points}");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        string jsonRep = JsonConvert.SerializeObject(new
        {
            Type = "Simple",
            Name = _shortName,
            Description = _description,
            Points = _points,
            IsComplete = _isComplete
        }, Formatting.Indented);

        return jsonRep;
    }
}