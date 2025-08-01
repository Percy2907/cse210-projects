using System;

class Program
{
    static void Main(string[] args)
    {
        string choice;

        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            Activity activity = null;

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
                    Console.WriteLine("Goodbye! Come back soon to reflect again.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose 1–4.");
                    Thread.Sleep(1500);
                    continue;
            }

            activity.Perform();
            Console.WriteLine("\nPress Enter to return to the main menu.");
            Console.ReadLine();

        } while (choice != "4");
    }
}

// W05 Project: Mindfulness Program – Percy Yarleque
//
// Creativity and Enhancements:
// - Custom spinner animation and countdown for better user interaction.
// - Prompts are randomly selected (may repeat if session duration is long).
// - User input validation for session duration.
// - Guided experience with well-timed messages and pacing.