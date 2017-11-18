using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.BusinessLogic
{
    public class FuelBusinessLogic
    {
        public double CalculateAvgConsumption(int fuel, int distance)
        {
            double avg = ((double)fuel / distance)*100;
            return avg;
        }
    }
}