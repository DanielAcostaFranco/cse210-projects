using System;
using System.Text; // ← necesario para mostrar emojis en consola

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; // ← habilita soporte para emojis
        Journal journal = new Journal();
        journal.StartJournal();
    }
}
