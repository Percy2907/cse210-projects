using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

        Console.Title = "Scripture Memorizer";
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("         SCRIPTURE MEMORIZER TOOL          ");
        Console.WriteLine("===========================================\n");

        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "scriptures.txt");
        Console.WriteLine("Loading scriptures from: " + fullPath);
        Console.WriteLine();

        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found. Please check the file 'scriptures.txt'.");
            return;
        }

        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        Console.Write("Choose difficulty (1=Easy, 2=Medium, 3=Hard): ");
        string levelInput = Console.ReadLine().Trim();
        int hideCount = levelInput == "3" ? 5 : levelInput == "2" ? 3 : 1;

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress [Enter] to hide words, type 'hint' to reveal one word, or 'quit' to exit:");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;
            else if (input == "hint")
                scripture.RevealOneHiddenWord();
            else
                scripture.HideRandomWords(hideCount);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Press any key to exit.");
        Console.ReadKey();
    }

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        var scriptures = new List<Scripture>();

        if (!File.Exists(filename))
            return scriptures;

        foreach (string line in File.ReadAllLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split('|');
            if (parts.Length < 4) continue;

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);
            int endVerse = startVerse;
            string text;

            if (int.TryParse(parts[3], out int parsedEndVerse) && parts.Length >= 5)
            {
                endVerse = parsedEndVerse;
                text = parts[4];
            }
            else
            {
                text = parts[3];
            }

            Reference reference = new Reference(book, chapter, startVerse, endVerse);
            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }
}

// W03 Project: Scripture Memorizer - Percy Yarleque
//
// Creativity and Enhancements:
// - Loads scriptures from an external text file to allow easy updates without modifying code.
// - Allows the user to select a difficulty level (Easy, Medium, Hard) which controls how many words are hidden.
// - Implements a "hint" command that reveals one hidden word at a time to assist memorization.