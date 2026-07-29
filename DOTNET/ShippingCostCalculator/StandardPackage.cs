using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingCostCalculator
{
    class StandardPackage : IShippingCost
    {
        public double CalculateCost(double weight, double distance)
        {
            return weight * distance * 0.50;
        }
    }
}
