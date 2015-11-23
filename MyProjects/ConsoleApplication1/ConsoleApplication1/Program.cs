using System;
using System.Net;
using System.IO;
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
            htmlScrape();
            Console.ReadKey();
        }
        static void htmlScrape()
        {
            string path = @"C:\Users\Shawn\Documents\Visual Studio 2015\Projects\html.txt";
            string url = "view-source:https://www.google.com/search?q=google+weather&rlz=1C1CHFX_enUS653US653&oq=google+weather&aqs=chrome..69i57j0j69i60l2j0l2.1353j1j7&sourceid=chrome&es_sm=122&ie=UTF-8";
            WebClient client = new WebClient();
            string s = client.DownloadString(url);
            try
            {
                File.WriteAllText(path, s);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
        static void time()
        {
            string printTime = DateTime.Now.ToString("h:mm tt");
            Console.WriteLine(printTime);
        }
    }
}
