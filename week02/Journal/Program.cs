using System;

class Program
{
    static void Main(string[] args)
   {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n===== Journal Menu =====");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");
        Console.Write("What would you like to do? ");
    }
}

class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;
    private Random _random;

    public Journal()
    {
        _entries = new List<Entry>();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something new I learned today?",
            "What act of kindness did I perform or witness today?"
        };
        _random = new Random();
    }

    public void WriteNewEntry()
    {
        // Get a random prompt
        string prompt = _prompts[_random.Next(_prompts.Count)];
        
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();
        
        // Create a new entry and add it to the journal
        Entry entry = new Entry
        {
            Date = DateTime.Now.ToShortDateString(),
            Prompt = prompt,
            Response = response
        };
        
        _entries.Add(entry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nThe journal is empty.");
            return;
        }

        Console.WriteLine("\n===== Journal Entries =====");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.GetDisplayText());
            Console.WriteLine();
        }
    }

    public void SaveToFile()
    {
        Console.Write("\nEnter filename to save: ");
        string filename = Console.ReadLine();
        
        try
        {
            string jsonString = JsonSerializer.Serialize(_entries);
            File.WriteAllText(filename, jsonString);
            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        Console.Write("\nEnter filename to load: ");
        string filename = Console.ReadLine();
        
        try
        {
            if (File.Exists(filename))
            {
                string jsonString = File.ReadAllText(filename);
                _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
                Console.WriteLine("Journal loaded successfully!");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}

class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string GetDisplayText()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\n{Response}";      
    }
}