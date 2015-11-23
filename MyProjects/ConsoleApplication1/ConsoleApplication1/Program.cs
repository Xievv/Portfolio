using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            pullWeather pull = new pullWeather();
            string raw_data = pull.weatherScrape();
            pull.weatherSearch(raw_data);
            pull.displayWeather();

            Console.ReadKey();
        }
    }
}
