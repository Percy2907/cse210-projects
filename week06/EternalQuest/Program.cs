using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestManager manager = new QuestManager();
            string savePath = "goals.txt";

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n=== Eternal Quest Menu ===");
                Console.WriteLine("1. Create Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Show Goals");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Quit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        manager.CreateGoalFromConsole();
                        break;
                    case "2":
                        manager.RecordEventFromConsole();
                        break;
                    case "3":
                        manager.ShowGoals();
                        break;
                    case "4":
                        manager.SaveToFile(savePath);
                        break;
                    case "5":
                        manager.LoadFromFile(savePath);
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}

// W06 Project: Eternal Quest Program – Percy Yarleque
//
// Creativity and Enhancements:
// - Leveling system that increases level every 1000 points with celebratory messages.
// - Infinity symbol to represent eternal goals in the display.
// - Checklist feature showing current and target progress, awarding bonuses upon completion.
// - Save/Load functionality that preserves score, level, and each goal's internal state.
// - Strict adherence to single-responsibility principle, with each class in its own file.
// - Consistent naming conventions: TitleCase for types/methods and _underscoreCamelCase for private fields.
// - Centralized GoalSerializer class to handle all parsing and deserialization logic.