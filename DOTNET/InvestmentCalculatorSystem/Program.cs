namespace Day1_InvestmentCalculatorSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Investment Type (Simple/Compound): ");
            string investmentType = Console.ReadLine()??"";

            Console.Write("Enter Principal Amount: ");
            if (!double.TryParse(Console.ReadLine(), out double principal) || principal <= 0)
            {
                Console.WriteLine("Invalid Principal Amount.");
                return;
            }

            Console.Write("Enter Annual Rate (%): ");
            if (!double.TryParse(Console.ReadLine(), out double rate) || rate < 0 || rate > 100)
            {
                Console.WriteLine("Invalid Interest Rate.");
                return;
            }

            Console.Write("Enter Duration (Years): ");
            if (!double.TryParse(Console.ReadLine(), out double years) || years <= 0)
            {
                Console.WriteLine("Invalid Duration.");
                return;
            }

            IInvestmentCalculator calculator;

            if (investmentType.Equals("Simple", System.StringComparison.OrdinalIgnoreCase))
            {
                calculator = new SimpleInterestCalculator();
            }
            else if (investmentType.Equals("Compound", System.StringComparison.OrdinalIgnoreCase))
            {
                calculator = new CompoundInterestCalculator();
            }
            else
            {
                Console.WriteLine("Invalid Investment Type.");
                return;
            }

            double projectedValue = calculator.CalculateReturn(principal, rate, years);

            Console.WriteLine($"Projected Investment Value : {System.Math.Round(projectedValue, 2)}");
        }
    }
}