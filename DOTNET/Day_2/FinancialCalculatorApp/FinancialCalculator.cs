namespace Day2_FinancialCalculatorApp
{
    static class FinancialCalculator
    {
        public static double CalculateCompoundInterest(double principal, double rate, int time)
        {
            return CalculateCompoundInterest(principal, rate, time, 1);
        }

        public static double CalculateCompoundInterest(double principal, double rate, int time, int compoundingFrequency)
        {
            return principal * Math.Pow(1 + (rate / compoundingFrequency), compoundingFrequency * time);
        }
    }
}