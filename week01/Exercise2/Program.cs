using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for grade percentage
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);
        console.WriteLine($"Your grade is: {percent}%");

        // Determine letter grade based on percentage
        // A: 90-100, B: 80-89, C: 70-79, D: 60-69, F: 0-59
        // Print the letter grade and a message based on the grade

        string letter = "";
    
        if (percent >= 90)
        {
            letter = "A";
            Console.WriteLine(letter);
        }
        else if (percent >= 80)
        {
            letter = "B";
            Console.WriteLine(letter);
        }
        else if (percent >= 70)
        {
            letter = "C";
            Console.WriteLine(letter);
        }
        else if (percent >= 60)
        {
            letter = "D";
            Console.WriteLine(letter);
        }
        else
        {
            letter = "F";
            Console.WriteLine(letter);
        }

        Console.WriteLine($"Your grade is: {letter}");
        
        if (percent >= 70)
        {
            // If the grade is 70 or above, print a message congratulating the user
            Console.WriteLine("Congratulations!");
            Console.WriteLine("You passed!");
        }
        else
        {
            // If the grade is below 70, print a message encouraging the user 
            Console.WriteLine("Better luck next time!");
            Console.WriteLine("You can do it!");
            Console.WriteLine("Hello World! This is the Exercise2 Project.");
        }

    }
    
}

