namespace Day2_FinancialCalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double futureValue1 = FinancialCalculator.CalculateCompoundInterest(10000, 0.05, 10);

            double futureValue2 = FinancialCalculator.CalculateCompoundInterest(
                principal: 10000,
                rate: 0.05,
                time: 10,
                compoundingFrequency: 12);

            Console.WriteLine($"Future Value (Annually): {System.Math.Round(futureValue1, 2)}");
            Console.WriteLine($"Future Value (Monthly): {System.Math.Round(futureValue2, 2)}");
        }
    }
}