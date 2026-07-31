namespace Day1_InvestmentCalculatorSystem
{
    class SimpleInterestCalculator : IInvestmentCalculator
    {
        public double CalculateReturn(double principal, double rate, double years)
        {
            return principal + (principal * rate * years / 100);
        }
    }
}