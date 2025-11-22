using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override string GetDetailsString()
    {
        return _isComplete ? "[X] " : "[ ] " + _shortName + " (" + _description + ")";
    }

    public override string GetStringRepresentation()
    {
        return "SimpleGoal:" + _shortName + "|" + _description + "|" + _points + "|" + _isComplete;
    }
}