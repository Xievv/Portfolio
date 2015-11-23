using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            time();
            pullWeather pull = new pullWeather();
            string raw_data = pull.weatherScrape();
            pull.weatherSearch(raw_data);
            Console.ReadKey();
        }
        static void time()
        {
            string printTime = DateTime.Now.ToString("h:mm tt");
            Console.WriteLine(printTime);
        }
    }
}
