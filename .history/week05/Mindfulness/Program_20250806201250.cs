using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Start gratitude journal activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Activity activity;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    continue;
            }

            activity.Run();
        }
    }
}

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void ShowStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(5);
    }

    public void ShowEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(5);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} in {_duration} seconds.");
        ShowSpinner(5);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            foreach (string s in animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(200);
                Console.Write("\b \b");
            }
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("\b \b");
        }
    }

    public abstract void Run();
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        ShowStartingMessage();

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(4);
            Console.WriteLine();

            Console.Write("Breathe out... ");
            ShowCountdown(6);
            Console.WriteLine();
            Console.WriteLine();
        }

        ShowEndingMessage();
    }
}

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedPrompts;
    private List<string> _usedQuestions;
    private Random _random;

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        _usedPrompts = new List<string>();
        _usedQuestions = new List<string>();
        _random = new Random();
    }

    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear();
        }
        string prompt;
        do
        {
            int index = _random.Next(_prompts.Count);
            prompt = _prompts[index];
        } while (_usedPrompts.Contains(prompt));
        _usedPrompts.Add(prompt);
        return prompt;
    }

    private string GetRandomQuestion()
    {
        if (_usedQuestions.Count == _questions.Count)
        {
            _usedQuestions.Clear();
        }
        string question;
        do
        {
            int index = _random.Next(_questions.Count);
            question = _questions[index];
        } while (_usedQuestions.Contains(question));
        _usedQuestions.Add(question);
        return question;
    }

    public override void Run()
    {
        ShowStartingMessage();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.WriteLine($"> {GetRandomQuestion()}");
            ShowSpinner(10);
        }

        ShowEndingMessage();
    }
}

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _usedPrompts;
    private Random _random;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _usedPrompts = new List<string>();
        _random = new Random();
    }

    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear();
        }
        string prompt;
        do
        {
            int index = _random.Next(_prompts.Count);
            prompt = _prompts[index];
        } while (_usedPrompts.Contains(prompt));
        _usedPrompts.Add(prompt);
        return prompt;
    }

    public override void Run()
    {
        ShowStartingMessage();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        List<string> items = new List<string>();
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"You listed {items.Count} items!");

        ShowEndingMessage();
    }
}

public class GratitudeActivity : Activity
{
    public GratitudeActivity() : base("Gratitude Journal Activity", "This activity will help you focus on the positive aspects of your life by listing things you are grateful for. Gratitude can improve your mental well-being and overall happiness.")
    {
    }

    public override void Run()
    {
        ShowStartingMessage();
        Console.WriteLine("Take a moment to reflect on what you are grateful for.");
        Console.WriteLine("You will be prompted to enter items for your gratitude journal.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        List<string> gratefulItems = new List<string>();
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                gratefulItems.Add(item);
            }
        }

        Console.WriteLine($"You have recorded {gratefulItems.Count} items in your gratitude journal.");

        ShowEndingMessage();
    }
}