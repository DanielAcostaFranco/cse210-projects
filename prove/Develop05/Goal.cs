using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    public string _shortName;
    public string _description;
    public int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetDetails();
    public abstract string GetString();

    public static Goal CreateNewGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
            return new SimpleGoal(name, description, points);
        else if (type == "2")
            return new EternalGoal(name, description, points);
        else
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            return new ChecklistGoal(name, description, points, target, bonus);
        }
    }

    public static void DisplayGoals(List<Goal> goals)
    {
        Console.WriteLine("\nYour goals are:\n");
        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine((i + 1) + ". " + goals[i].GetDetails());
    }

    public static void SaveGoals(List<Goal> goals, int score)
    {
        Console.Write("\nEnter filename to save (e.g. goals.txt): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
            filename = "goals.txt";

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            foreach (Goal goal in goals)
                writer.WriteLine(goal.GetString());
        }
        Console.WriteLine("Goals saved to '" + filename + "'.\n");
    }

    public static List<Goal> LoadGoals(out int score)
    {
        Console.Write("\nEnter filename to load (e.g. goals.txt): ");
        string filename = Console.ReadLine();

        var goals = new List<Goal>();
        score = 0;

        if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return goals;
        }

        string[] lines = File.ReadAllLines(filename);
        score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] data = parts[1].Split('|');

            if (type == "SimpleGoal")
                goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
            else if (type == "EternalGoal")
                goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            else if (type == "ChecklistGoal")
                goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
        }
        Console.WriteLine("Goals loaded! Score: " + score + " points\n");
        return goals;
    }
}