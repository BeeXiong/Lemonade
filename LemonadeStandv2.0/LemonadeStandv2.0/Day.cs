using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class Day
    {
        Weather weatherCondition;
        Random rnd;
        public Day()
        {
            rnd = new Random();
            SetWeatherConditions();
            SetTemp();
        }
        public void SetWeatherConditions()
        {
            int Random = rnd.Next(50, 90);
            weatherCondition = new Weather();
            if (Random % 5 == 0)
            {
                weatherCondition.WeatherCondition = "raining";
            }
            else if (Random * 3 % 2 == 0)
            {
                weatherCondition.WeatherCondition = "cloudy";
            }
            else if (Random * 2 % 2 != 0)
            {
                weatherCondition.WeatherCondition = "sunny";
            }
            else
            {
                weatherCondition.WeatherCondition = "sunny";
            }         
        }
        public void SetTemp()
        {
            decimal Random = rnd.Next(60, 100);
            if (Random % 2 == 0)
            {
                weatherCondition.Temperature = Random;
            }
            else
            {
                weatherCondition.Temperature = (Random * 1.1m);
            }
        }

    }
}
