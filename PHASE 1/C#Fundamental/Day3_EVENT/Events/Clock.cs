using System;

namespace Day3_EVENT
{
    public class Clock
    {
        private int second;
        public delegate void ClockTickHandler(object clock, TimeInfoEventArgs timeInfoEvent);
        public event ClockTickHandler? clockTickEvent;

        public void OnTick(object clock, TimeInfoEventArgs timeInfoEvent)
        {
            if (clockTickEvent != null)
            {
                clockTickEvent(clock, timeInfoEvent);
            }
        }

        public void Run()
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1500);
                DateTime now = DateTime.Now;

                if (now.Second != this.second)
                {
                    TimeInfoEventArgs timeInfoEventArgs = new TimeInfoEventArgs(
                        now.Hour,
                        now.Minute,
                        now.Second
                    );

                    OnTick(this, timeInfoEventArgs);
                }
            }
        }
    }
}
