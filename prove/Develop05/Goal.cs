using System;

public abstract class Goal
{
    // Member Variables
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Getters
    public string GetShortName()
    {
        return _shortName;
    }
    public virtual int GetPoints()
    {
        return _points;
    }

    // Constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Empty Virtual Methods
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        string checkbox = "[ ]";

        if (IsComplete())
        {
            checkbox = "[X]";
        }

        string details = $"{checkbox} {_shortName} ({_description})";

        return details;
    }
    public abstract string GetStringRepresentation();
}