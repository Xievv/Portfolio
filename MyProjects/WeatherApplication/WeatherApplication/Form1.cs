using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace WeatherApplication
{
    public partial class Form1 : Form
    {
        pullWeather pull = new pullWeather();
        System.Threading.Thread test;

        public Form1()
        {            
            InitializeComponent();
            /*
            string raw_data = pull.weatherScrape();

            pull.weatherSearch(raw_data);
            pull.getTime();

            labelCity.Text = "City: " + pull.city;
            labelState.Text = "State: " + pull.state;
            labelSkies.Text = "Skies: " + pull.skies;
            labelTemperature.Text = "Temperature: " + pull.temperature;
            labelTime.Text = pull.time;
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void fetchData()
        {
            
            string raw_data = pull.weatherScrape();

            pull.weatherSearch(raw_data);
            pull.getTime();
            labelCity.Text = "City: " + pull.city;
            labelState.Text = "State: " + pull.state;
            labelSkies.Text = "Skies: " + pull.skies;
            labelTemperature.Text = pull.temperature;
            labelTime.Text = pull.time;
        }
        private void weatherDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fetchData();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
