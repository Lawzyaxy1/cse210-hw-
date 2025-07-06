using System;

class Program
{
    static void Main(string[] args)
    {
        // This program is part of the Exercise5 Project
        // Welcome message
        Console.WriteLine("Welcome to the program!");
        
        // Ask for the user's name
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        
        // Ask for the user's favorite number
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());
        
        // Calculate the square of the number
        int square = favoriteNumber * favoriteNumber;
        
        // Display the result with the user's name
        Console.WriteLine($"{name}, the square of your number is {square}");
        // Goodbye message
        Console.WriteLine("Thank you for using the program!");
        Console.WriteLine("Goodbye!");
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
    }
}
// This program asks the user for their name and favorite number, calculates the square of the number, and displays the result.
// It also includes a welcome message and a goodbye message at the end.}