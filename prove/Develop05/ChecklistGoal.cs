using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _current;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _current = 0;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int bonus, int target, int current)
        : base(name, description, points)
    {
        _target = target;
        _current = current;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _current++;
        return _current >= _target ? _points + _bonus : _points;
    }

    public override string GetDetailsString()
    {
        string mark = _current >= _target ? "[X]" : "[ ]";
        return mark + " " + _shortName + " (" + _description + ") -- Currently completed: " + _current + "/" + _target;
    }

    public override string GetStringRepresentation()
    {
        return "ChecklistGoal:" + _shortName + "|" + _description + "|" + _points + "|" + _bonus + "|" + _target + "|" + _current;
    }
}