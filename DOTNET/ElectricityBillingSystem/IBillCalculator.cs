

namespace ElectricityBillingSystem
{
    interface IBillCalculator
    {
        double CalculateBill(double units, double rate, double fixedCharges);
    }
}
