using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Journal journal = new Journal();
        journal.StartJournal();
    }
}
