using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Please choose one of the following:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    Entry newEntry = new Entry
                    {
                        _date = DateTime.Now.ToShortDateString(),
                        _promptText = prompt,
                        _entryText = response
                    };
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter a filename to save to: ");
                    string saveFile = Console.ReadLine();
                    string savePath = Path.Combine(Directory.GetCurrentDirectory(), saveFile);
                    journal.SaveToFile(savePath);
                    Console.WriteLine($"Journal saved to: {savePath}");
                    break;

                case "4":
                    Console.Write("Enter a filename to load from: ");
                    string loadFile = Console.ReadLine();
                    string loadPath = Path.Combine(Directory.GetCurrentDirectory(), loadFile);

                    if (File.Exists(loadPath))
                    {
                        journal.LoadFromFile(loadPath);
                        Console.WriteLine($"Journal loaded successfully from: {loadPath}");
                    }
                    else
                    {
                        Console.WriteLine("Error: That file does not exist. Please check the name and try again.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}

// W02 Project: Journal Program - Percy Yarleque
//
// Creativity and Enhancements:
// - Added a custom list of prompts in the PromptGenerator class.
// - Structured the code to make it easy to add future features like mood, emotion, or tags.
// - Improved formatting in Entry.Display() for better readability.
// - Displayed full file paths after saving or loading a journal for clarity.
// - Added error handling when loading a file that doesn't exist.