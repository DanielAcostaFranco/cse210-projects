using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetDetails()
    {
        return "[ ] " + _shortName + " (" + _description + ")";
    }

    public override string GetString()
    {
        return "EternalGoal:" + _shortName + "|" + _description + "|" + _points;
    }
}