namespace Day3_SYNCHRONOUS
{
    public class Program
    {
        private static async void PrintPrimeNumber(int start, int end)
        {
            await Task.Run(() =>
            {
                int count;
                
                for (int i = start; i <= end; i++)
                {
                    count = 0;

                    for (int j = 2; j <= i / 2; j++)
                    {
                        if (i % j == 0)
                        {
                            count++;
                            break;
                        }
                    }

                    if (count == 0 && i != 1)
                    {
                        Console.Write("{0} ", i);
                        Task.Delay(200).Wait();
                    }
                }
            });
        }

        public static void Main(string[] args)
        {
            PrintPrimeNumber(0, 100);
            PrintPrimeNumber(101, 200);
            Console.ReadKey();
        }
    }
}
