using System;

class Program
{
    static void Main(string[] args)
    {
         Console.WriteLine("Hello World! This is the Exercise3 Project.");
        // Ask for the magic number
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());
        
        bool hasGuessedCorrectly = false;
        
        // It will Continue to keep asking for guesses until the user guesses correctly
        while (!hasGuessedCorrectly)
        {
            // Ask for the user's guess
            Console.Write("What is your guess? ");
            int userGuess = int.Parse(Console.ReadLine());
            
            // Compare the guess with the magic number
            if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                hasGuessedCorrectly = true;
            }

        }
    }
}