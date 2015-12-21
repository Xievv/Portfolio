using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace WeatherApplication
{
    class pullWeather
    {
        public string city;
        public string state;
        public string skies;
        public string temperature;
        public string time;

        public string weatherScrape()
        {
            string data = null;  // This string will hold the html code for gathering weather information
            string urlAddress = "http://www.wunderground.com/cgi-bin/findweather/getForecast?query=Manchester%2C+NH";  // URL used to grab Manchester, NH weather

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);   // Sends request to urlAddress
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();        // Gets html response
                StreamReader readStream = new StreamReader(response.GetResponseStream()); // Using StreamReader to read html into string variable data
                data = readStream.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured in \"weatherScrape\": " + e);
            }
            return data;
        }
        public void weatherSearch(string raw_data)
        {
            string[] raw = null;                                                         // Initialize raw array
            Regex regex = new Regex("(<meta property=\"og:title).*");                    // Searches for weather data in raw_data string
            if (regex.IsMatch(raw_data))
            {
                string raw_weather = regex.Match(raw_data).ToString();                   // Creates new string of the found weather data
                raw = Regex.Split(raw_weather, ("\\s(|)|(content=\")|(,)|(&)|(\")"));    // Split string into array
            }
            else
            {
                Console.WriteLine("Error has occured: No match found.");
            }
            /*for (int i = 0; i < raw.Length; i++)                                        // Used for trouble shooting, formats line number from array
            {
                Console.WriteLine("{0}) {1}", i, raw[i]);
            }*/
            city = raw[10];
            state = raw[14];
            skies = raw[24] + " " + raw[26];
            temperature = raw[18];
        }
        public void getTime()
        {
            string currentTime = DateTime.Now.ToString();
            string prompt = "Data pulled on " + currentTime;
            time = prompt;
        }
    }
}

