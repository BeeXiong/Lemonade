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
        List<Customer> potentialCustomers;  
        Weather dailyWeatherConditions;
        
        public Customer(double playerDisposition)
        {
            dailyWeatherConditions = new Weather();
            potentialCustomers = new List<Customer>();
        }
        public void GenerateCustomer()
        {
           
        }
        public void CalculateDisposition()
        {

        }
    }
}
