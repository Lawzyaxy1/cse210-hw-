using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask username
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

         // Print the username out
        Console.WriteLine($"Your name is {last}, {first} {last}.");
        
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
    }
}