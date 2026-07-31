namespace Day1_InvestmentCalculatorSystem
{
    class CompoundInterestCalculator : IInvestmentCalculator
    {
        public double CalculateReturn(double principal, double rate, double years)
        {
            return principal * System.Math.Pow(1 + rate / 100, years);
        }
    }
}