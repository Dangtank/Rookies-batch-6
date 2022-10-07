namespace Day3_EVENT
{
    public class DisplayClock
    {
        public void Subcribe(Clock clock)
        {
            clock.clockTickEvent += new Clock.ClockTickHandler(ShowClock);
        }

        public void ShowClock(object clock, TimeInfoEventArgs timeInfoEventArgs)
        {
            Console.WriteLine(
                $"{timeInfoEventArgs.hour} : {timeInfoEventArgs.minute}: {timeInfoEventArgs.second}"
            );
        }
    }
}
