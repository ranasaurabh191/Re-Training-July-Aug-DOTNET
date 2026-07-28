namespace RetailBillingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double price, discount;
            int quantity;

            Console.Write("Enter Item Price: ");
            if (!double.TryParse(Console.ReadLine(), out price) || price < 0)
            Console.WriteLine("Invalid Price.");
            
            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
            Console.WriteLine("Invalid Quantity."); 

            Console.Write("Enter Discount Percentage: ");
            if (!double.TryParse(Console.ReadLine(), out discount) || discount < 0 || discount > 100)
            Console.WriteLine("Invalid Discount Percentage.");
                 
            double subtotal = price * quantity;
            double discountAmount = subtotal * discount * 0.01;
            double finalAmount = subtotal - discountAmount;

            Console.WriteLine("\n----- BILL -----");
            Console.WriteLine($"Subtotal          : {Math.Round(subtotal, 2)}");
            Console.WriteLine($"Discount Amount   : {Math.Round(discountAmount, 2)}");
            Console.WriteLine($"Final Payable     : {Math.Round(finalAmount, 2)}");
        }
    }
}
