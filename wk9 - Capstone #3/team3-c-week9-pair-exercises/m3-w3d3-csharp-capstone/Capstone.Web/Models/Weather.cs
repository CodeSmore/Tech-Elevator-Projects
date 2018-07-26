using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Models
{
    public class Weather : IWeatherDAO
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public bool Celcius { get; set; }
        public bool Farhrenheit { get; set; }
        public char Unit { get; set; }

        public void TempConversion(char tempUnitChar)
        {
            Unit = tempUnitChar;
            switch (Unit)
            {
                case 'F':
                    High = ConvertToCelcius(High);
                    Low = ConvertToCelcius(Low);
                    Celcius = true;
                    Farhrenheit = false;
                    Unit = 'C';
                    break;

                case 'C':
                    High = ConvertToFahrenheit(High);
                    Low = ConvertToFahrenheit(Low);
                    Farhrenheit = true;
                    Celcius = false;
                    Unit = 'F';
                    break;

                default:
                    Unit = 'F';
                    Farhrenheit = true;
                    Celcius = false;
                    break;
            }
        }

        public List<Weather> GetForcast(string parkCode)
        {
            return new List<Weather>();
        }

        public int ConvertToFahrenheit(int celcius)
        {
            int resultFahrenheit;

            resultFahrenheit = (int)((celcius * 1.8) + 32);

            return resultFahrenheit;
        }

        public int ConvertToCelcius(int fahrenheit)
        {
            int resultCelcius;

            resultCelcius = (int)((fahrenheit - 32) / 1.8);

            return resultCelcius;
        }
    }
}