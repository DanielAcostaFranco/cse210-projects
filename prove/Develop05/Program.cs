using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        ShowWelcomeAnimation();

        Menu menu = new Menu();
        menu.StartMenu();
    }

    private static void ShowWelcomeAnimation()
    {
        Console.Clear();
        Console.WriteLine("Eternal Quest\n");
        Console.WriteLine("Loading your goals...\n");

        char[] spinner = { '◜', '◠', '◝', '◞', '◡', '◟' };
        for (int i = 0; i < 36; i++)
        {
            Console.Write($"\r{spinner[i % spinner.Length]} Loading...     ");
            Thread.Sleep(90);
        }

        Console.Write("\r✓ Loaded! Welcome back!      ");
        Thread.Sleep(800);
        Console.Clear();
    }
}