using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your score?");
        int score = int.Parse(Console.ReadLine());

        string letter;

        if (score >= 90)
        {
            //Console.WriteLine("Your grade letter is A");
            letter = "A";
        }

        else if (score >= 80)
        {
            //Console.WriteLine("Your grade letter is B");
            letter = "B";
        }

        else if (score >= 70)
        {
            //Console.WriteLine("Your grade letter is C");
            letter = "C";
        }

        else if (score >= 60)
        {
            //Console.WriteLine("Your grade letter is D");
            letter = "D";
        }

        else
        {
            //Console.WriteLine("Your grade letter is F");
            letter = "F";
        }

        Console.WriteLine($"Your grade letter is {letter}");

        if (letter == "A" || letter == "B" || letter == "C")
        {
            Console.WriteLine("Congratulations, you passed the class");
        }

        else
        {
            Console.WriteLine("You will need to take this course again.");
        }




    }
}