using System;

class Program
{
    static void Main(string[] args)
    {
       string playAgain;

        do
        {
        
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int numberOfGuesses = 0;
            int userGuess = -1;

            Console.WriteLine("Welcome to 'Guess My Number'");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            while (userGuess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                userGuess = int.Parse(input);
                numberOfGuesses++;

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
                    Console.WriteLine($"You guessed it in {numberOfGuesses} guesses.");
                }
            }

            Console.Write("Would you like to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes" || playAgain == "y");

        Console.WriteLine("Thanks for playing. Goodbye!");
    }
}