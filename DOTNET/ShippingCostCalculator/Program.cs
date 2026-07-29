namespace ShippingCostCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Package Type (Standard/Express): ");
            string packageType = Console.ReadLine()?? "";

            Console.Write("Enter Weight (kg): ");
            if (!double.TryParse(Console.ReadLine(), out double weight) || weight <= 0)
            {
                Console.WriteLine("Invalid Weight."); 
                return;
            }

            Console.Write("Enter Distance (km): ");
            if (!double.TryParse(Console.ReadLine(), out double distance) || distance <= 0)
            {
                Console.WriteLine("Invalid Distance.");
                return;
            }

            IShippingCost shippingCost;

            if (packageType.Equals("Standard", System.StringComparison.OrdinalIgnoreCase))
            {
                shippingCost = new StandardPackage();
            }
            else if (packageType.Equals("Express", System.StringComparison.OrdinalIgnoreCase))
            {
                shippingCost = new ExpressPackage();
            }
            else
            {
                Console.WriteLine("Invalid Package Type.");
                return;
            }

            double cost = shippingCost.CalculateCost(weight, distance);

            Console.WriteLine($"Shipping Cost : {Math.Round(cost, 2)}");
        }
    }
}
