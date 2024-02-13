using System;
using Newtonsoft.Json;

public class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {

    }

    // Overridden Methods
    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You have earned {_points}");
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetStringRepresentation()
    {
        string jsonRep = JsonConvert.SerializeObject(new
        {
            Type = "Eternal",
            Name = _shortName,
            Description = _description,
            Points = _points
        }, Formatting.Indented);

        return jsonRep;
    }
}