using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WeatherApplication
{
    public partial class Form1 : Form
    {
        pullWeather pull = new pullWeather();       
        public Form1()
        {            
            InitializeComponent();

            string raw_data = pull.weatherScrape();
            pull.weatherSearch(raw_data);
            labelCity.Text = "City: " + pull.city;
            labelState.Text = "State: " + pull.state;
            labelSkies.Text = "Skies: " + pull.skies;
            labelTemperature.Text = "Temperature: " + pull.temperature;

        }
    }
}
