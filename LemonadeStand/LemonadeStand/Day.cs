using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        public List<Day> totalGameDays;
        public Weather conditions;
        public Day()
        {
            totalGameDays = new List<Day>();
            conditions = new Weather();
        }
        public void GenerateConditions()
        {

        }

    }
}
