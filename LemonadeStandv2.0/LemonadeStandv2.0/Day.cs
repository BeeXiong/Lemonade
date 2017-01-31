using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class Day
    {     
        Random rnd;
        public List<Customer> lemonadeCustomers;
        public List<Customer> purchasingCustomers;
        public Weather WeatherCondition { get; set; }
        public Day(Random rndNumber)
        {
            rnd = rndNumber;
            SetWeatherConditions();
            SetTemp();
            lemonadeCustomers = new List<Customer>();
            purchasingCustomers = new List<Customer>();
            int totalCustomers;
            totalCustomers = GenerateTotalCustomers(rnd);
            AddCustomers(totalCustomers);
        }
        public int GenerateTotalCustomers(Random number)
        {
            int totalCustomers;
            if (WeatherCondition.Temperature > 80 && WeatherCondition.Condition == "sunny" || WeatherCondition.Condition == "cloudy")//ideal situation
            {
                totalCustomers = number.Next(50, 100);
                return totalCustomers;
            }
            else if (WeatherCondition.Temperature < 55 || WeatherCondition.Condition == "raining")// terrible day
            {
                totalCustomers = rnd.Next(1, 40);
                return totalCustomers;
            }
            else if (WeatherCondition.Temperature < 79 && (WeatherCondition.Condition == "sunny" || WeatherCondition.Condition == "cloudy"))// okay day
            {
                totalCustomers = rnd.Next(30, 70);
                return totalCustomers;
            }
            else
            {
                return default(int);
            }
        }
        public void AddCustomers(int customerAmount)
        {
            int i;
            for (i = 0; i < customerAmount; i++)
            {
                lemonadeCustomers.Add(new Customer(rnd));
            }
        }
        public void SetWeatherConditions()
        {
            int Random = rnd.Next(50, 85);
            WeatherCondition = new Weather();
            if (Random % 5 == 0)
            {
                WeatherCondition.Condition = "raining";
            }
            else if (Random * 3 % 2 == 0)
            {
                WeatherCondition.Condition = "cloudy";
            }
            else if (Random * 2 % 2 != 0)
            {
                WeatherCondition.Condition = "sunny";
            }
            else
            {
                WeatherCondition.Condition = "sunny";
            }         
        }
        public void SetTemp()
        {
            decimal Random = rnd.Next(60, 100);
            if (Random % 2 == 0)
            {
                WeatherCondition.Temperature = Random;
            }
            else
            {
                WeatherCondition.Temperature = (Random * 1.1m);
            }
        }

    }
}
