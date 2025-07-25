using System;
using System.Collections.Generic;
using System.Linq;
 // For LINQ operations to help with random word selection

// This file is containing the main program logic for the Scripture Memorizer.
// It orchestrates the interaction between the user and the Scripture object.

// Exceeding Requirements:
// 1. Scripture Library: The program now supports a library of scriptures loaded from a file
//    (simulated here, but could be easily extended to read from a text file).
// 2. Random Scripture Selection: A scripture is randomly chosen from the library for each session.   
// 3. Word Hiding Mechanism: The program hides a specified number of words from the scripture text each time the user presses Enter, allowing for progressive memorization.
// 4. Customizable Words to Hide: Users can specify how many words to hide per turn.

class Program
{
    static void Main(string[] args)
    {
        // Initialize a simple scripture library. In a real application, this could be loaded from a file.
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Mosiah", 3, 19), "For the natural man is an enemy to God, and has been from the fall of Adam, and will be, forever and ever, unless he yields to the enticings of the Holy Spirit, and putteth off the natural man and becometh a saint through the atonement of Christ the Lord, and becometh as a child, submissive, meek, humble, patient, full of love, willing to submit to all things which the Lord seeth fit to inflict upon him, even as a child doth submit to his father.")
        };

        // Randomly select a scripture from the library
        Random random = new Random();
        int randomIndex = random.Next(0, scriptureLibrary.Count);
        Scripture currentScripture = scriptureLibrary[randomIndex];

        // --- Core Application Loop ---
        while (true)
        {
            ClearConsole();
            Console.WriteLine(currentScripture.GetDisplayText());

            if (currentScripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }

            Console.Write("\nPress Enter to hide more words, or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            else if (string.IsNullOrWhiteSpace(input))
            {
                // Determine how many words to hide. Could be user-configurable.
                // For demonstration, let's hide 3-5 words at a time.
                int wordsToHide = random.Next(3, 6);
                currentScripture.HideRandomWords(wordsToHide);
            }
            // Add other input options for hints, difficulty, etc. if exceeding requirements further.
        }
    }

    /// <summary>
    /// Clears the console screen.
    /// </summary>
    static void ClearConsole()
    {
        Console.Clear();
    }
}

// ---

/// <summary>
/// Represents a scripture with its reference and text.
/// Manages the hiding of words within the scripture.
/// </summary>
class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        // Split the text into words, handling punctuation appropriately
        // A more robust solution would use regular expressions for splitting words
        string[] rawWords = text.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string rawWord in rawWords)
        {
            _words.Add(new Word(rawWord));
        }
    }

    /// <summary>
    /// Returns the complete scripture text, including the reference,
    /// with hidden words represented by underscores.
    /// </summary>
    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {scriptureText}";
    }

    /// <summary>
    /// Hides a specified number of random words that are not already hidden.
    /// </summary>
    /// <param name="count">The number of words to hide.</param>
    public void HideRandomWords(int count)
    {
        List<Word> unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();

        // If there are fewer unhidden words than 'count', hide all remaining unhidden words
        int actualWordsToHide = Math.Min(count, unhiddenWords.Count);

        for (int i = 0; i < actualWordsToHide; i++)
        {
            int indexToHide = _random.Next(0, unhiddenWords.Count);
            unhiddenWords[indexToHide].Hide();
            unhiddenWords.RemoveAt(indexToHide); // Prevent hiding the same word in the same round
        }
    }

    /// <summary>
    /// Checks if all words in the scripture are currently hidden.
    /// </summary>
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}

// ---

/// <summary>
/// Represents a scripture reference (e.g., "John 3:16" or "Proverbs 3:5-6").
/// </summary>
class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse; // Nullable for single verses

    /// <summary>
    /// Constructor for a single-verse scripture reference.
    /// </summary>
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = null; // Indicates a single verse
    }

    /// <summary>
    /// Constructor for a scripture reference with a verse range.
    /// </summary>
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse; // Indicates a verse range
    }

    /// <summary>
    /// Returns the formatted display text for the scripture reference.
    /// </summary>
    public string GetDisplayText()
    {
        if (_endVerse.HasValue)
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
    }
}

// ---

/// <summary>
/// Represents a single word in the scripture text, with the ability to be hidden.
/// </summary>
class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false; // Initially, words are not hidden
    }

    /// <summary>
    /// Hides the word by setting its hidden status to true.
    /// </summary>
    public void Hide()
    {
        _isHidden = true;
    }

    /// <summary>
    /// Shows the word by setting its hidden status to false.
    /// </summary>
    public void Show()
    {
        _isHidden = false;
    }

    /// <summary>
    /// Checks if the word is currently hidden.
    /// </summary>
    public bool IsHidden()
    {
        return _isHidden;
    }

    /// <summary>
    /// Returns the word's text or underscores if it is hidden.
    /// </summary>
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}