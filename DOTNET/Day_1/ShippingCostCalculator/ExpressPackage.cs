using System;
using System.Collections.Generic;
using System.Text;

namespace Day1_ShippingCostCalculator
{
    class ExpressPackage : IShippingCost
    {
        public double CalculateCost(double weight, double distance)
        {
            return weight * distance * 0.80;
        }
    }
}
