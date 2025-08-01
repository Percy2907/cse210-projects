public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", 
        "This activity will help you relax by guiding your breathing in and out slowly.\nClear your mind and focus on your breath.")
    { }

    public override void Perform()
    {
        Start();
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            Countdown(4);
            Console.WriteLine("Now breathe out...");
            Countdown(6);
        }

        End();
    }
}