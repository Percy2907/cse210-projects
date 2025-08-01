public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself?",
        "How did you feel afterwards?",
        "How can you apply this in the future?"
    };

    public ReflectionActivity() : base("Reflection", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience.\nIt will help you recognize the power within you.")
    { }

    public override void Perform()
    {
        Start();
        Console.WriteLine($"\nConsider the following prompt:\n>>> {GetRandomPrompt()} <<<\n");
        ShowSpinner(4);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"\n> {GetRandomQuestion()}");
            ShowSpinner(5);
        }

        End();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }
}