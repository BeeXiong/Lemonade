using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public List<Weather> weatherConditions;
        private string condition;
        private decimal temperture;
        Random rnd;
        public Weather()
        {
            weatherConditions = new List<Weather>();
            rnd = new Random();
        }
        public void SetCondition()
        {
            int Random = rnd.Next(50, 90);
            if (Random % 5 == 0)
            {
                condition = "raining";
            }
            else if (Random*3 % 2 == 0)
            {
                condition = "cloudy";
            }
            else if (Random*2 % 2 != 0)
            {
                condition = "sunny";
            }
            else
            {
                condition = "sunny";
            }
        }
        public void SetTemp()
        {
            
            decimal Random = rnd.Next(60, 100);
            if (Random % 2 == 0)
            {
                temperture = Random;
            }
            else
            {
                temperture = (Random * 1.1m);
            }
        }
        public decimal GetTemperture()
        {
            return temperture;
        }
        public string GetConditions()
        {
            return condition;
        }
        public void DisplayWeather()
        {
            Console.WriteLine("It is currently {0} and {1}. ", GetTemperture(), GetConditions());
        }
    }
}
