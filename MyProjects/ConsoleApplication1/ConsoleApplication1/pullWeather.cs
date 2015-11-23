using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class pullWeather
    {
        public string location;
        public string skies;
        public int temperature;

        public string weatherScrape()
        {
            string data = null;
            string urlAddress = "http://www.wunderground.com/cgi-bin/findweather/getForecast?query=Manchester%2C+NH";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();

            }
            return data;
        }
        public void weatherSearch(string raw_data)
        {
            Console.WriteLine(raw_data);
        }
    }
}
