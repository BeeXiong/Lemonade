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
        List<Customer> lemonadeCustomers;
        public Day(Random rndNumber)
        {
            rnd = rndNumber;
            SetWeatherConditions();
            SetTemp();
            lemonadeCustomers = new List<Customer>();
            int totalCustomers;
            totalCustomers = GenerateTotalCustomers(rnd);
            AddCustomers(totalCustomers);
        }
        public int GenerateTotalCustomers(Random number)
        {
            int totalCustomers;
            if (weatherCondition.Temperature > 80 && weatherCondition.Condition == "sunny" || weatherCondition.Condition == "cloudy")//ideal situation
            {
                totalCustomers = number.Next(50, 100);
                return totalCustomers;
            }
            else if (weatherCondition.Temperature < 55 || weatherCondition.Condition == "raining")// terrible day
            {
                totalCustomers = rnd.Next(1, 40);
                return totalCustomers;
            }
            else if (weatherCondition.Temperature < 79 && (weatherCondition.Condition == "sunny" || weatherCondition.Condition == "cloudy"))// okay day
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
            weatherCondition = new Weather();
            if (Random % 5 == 0)
            {
                weatherCondition.Condition = "raining";
            }
            else if (Random * 3 % 2 == 0)
            {
                weatherCondition.Condition = "cloudy";
            }
            else if (Random * 2 % 2 != 0)
            {
                weatherCondition.Condition = "sunny";
            }
            else
            {
                weatherCondition.Condition = "sunny";
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
