namespace Day3_EVENT
{
    public class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            DisplayClock displayClock = new DisplayClock();

            displayClock.Subcribe(clock);
            clock.Run();
        }
    }
}
