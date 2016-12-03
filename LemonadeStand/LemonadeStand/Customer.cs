using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        private double playerDisposition;
        List<string> potentialCustomers = new List<string>();
        Weather dailyWeatherConditions;
        
        public Customer(double playerDisposition)
        {
            dailyWeatherConditions = new Weather();
        }
        public void GenerateCustomer()
        {
            
        }
        public void CalculateDisposition()
        {

        }
    }
}
