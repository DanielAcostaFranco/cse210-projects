using System;
using System.Collections.Generic;
using System.IO;

public class Menu
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void StartMenu()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine("\nYou have " + _score + " points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Goal goal = Goal.CreateNewGoal();
                _goals.Add(goal);
            }
            else if (choice == "2")
            {
                Goal.DisplayGoals(_goals);
            }
            else if (choice == "3")
            {
                Goal.SaveGoals(_goals, _score);
            }
            else if (choice == "4")
            {
                _goals = Goal.LoadGoals(out _score);
            }
            else if (choice == "5")
            {
                Goal.DisplayGoals(_goals);
                Console.Write("\nWhich goal did you accomplish? (number): ");
                int index = int.Parse(Console.ReadLine());
                int earned = _goals[index - 1].RecordEvent();
                _score += earned;
                Console.WriteLine("Congratulations! You earned " + earned + " points!");
                Console.WriteLine("Total score: " + _score + " points.\n");
            }
            else if (choice == "6")
            {
                Console.WriteLine("\nThanks for playing! See you soon!\n");
            }
        }
    }
}