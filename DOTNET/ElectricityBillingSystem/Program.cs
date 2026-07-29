namespace ElectricityBillingSystem
{
    class ResidentialCustomer : IBillCalculator
    {
        public double CalculateBill(double units, double rate, double fixedCharges)
        {
            return (units * rate) + fixedCharges;
        }
    }

    class CommercialCustomer : IBillCalculator
    {
        public double CalculateBill(double units, double rate, double fixedCharges)
        {
            return (units * rate * 1.20) + fixedCharges;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string customerType;

            Console.Write("Enter Customer Type (Residential/Commercial): ");
            customerType = Console.ReadLine()??"";

            double units, rate, fixedCharges;

            Console.Write("Enter Units Consumed: ");
            if (!double.TryParse(Console.ReadLine(), out units) || units < 0)
            {
                Console.WriteLine("Invalid Units.");
                return;
            }

            Console.Write("Enter Rate Per Unit: ");
            if (!double.TryParse(Console.ReadLine(), out rate) || rate < 0)
            {
                Console.WriteLine("Invalid Rate.");
                return;
            }

            Console.Write("Enter Fixed Charges: ");
            if (!double.TryParse(Console.ReadLine(), out fixedCharges) || fixedCharges < 0)
            {
                Console.WriteLine("Invalid Fixed Charges.");
                return;
            }

            IBillCalculator calculator;

            if (customerType.Equals("Residential", StringComparison.OrdinalIgnoreCase))
            {
                calculator = new ResidentialCustomer();
            }
            else if (customerType.Equals("Commercial", StringComparison.OrdinalIgnoreCase))
            {
                calculator = new CommercialCustomer();
            }
            else
            {
                Console.WriteLine("Invalid Customer Type.");
                return;
            }

            double bill = calculator.CalculateBill(units, rate, fixedCharges);

            Console.WriteLine($"Total Bill : {Math.Round(bill, 2)}");
        }
    }
}