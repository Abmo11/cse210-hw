using System;
using Newtonsoft.Json;

public class ChecklistGoal : Goal
{
    // Member Variables
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Constructor
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    // For use in deserializing JSON file
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    // Overridden Methods
    public override void RecordEvent()
    {
        _amountCompleted++;

        Console.WriteLine($"Congratulations! You have earned {_points} points!");
        // Checks to see if goal has been accomplished
        if (_amountCompleted == _target)
        {
            Console.WriteLine($"Congratulations! You have earned {_bonus} bonus points!");
        }
    }
    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }
        return false;
    }
    public override string GetDetailsString()
    {
        string checkbox = "[ ]";

        if (IsComplete())
        {
            checkbox = "[X]";
        }

        string details = $"{checkbox} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";

        return details;
    }
    public override string GetStringRepresentation()
    {
        string jsonRep = JsonConvert.SerializeObject(new
        {
            Type = "Checklist",
            Name = _shortName,
            Description = _description,
            Points = _points,
            Target = _target,
            Bonus = _bonus,
            AmountCompleted = _amountCompleted
        }, Formatting.Indented);

        return jsonRep;
    }

    public override int GetPoints()
    {
        if (IsComplete())
        {
            return _bonus + _points;
        }
        return _points;
    }
}