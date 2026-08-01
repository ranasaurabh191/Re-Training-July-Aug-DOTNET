using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== E-Commerce Discount Calculator ===");

        Console.Write("Enter Customer Type (R/P/V): ");
        char customerType = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Enter Purchase Amount: ");
        double purchaseAmount = Convert.ToDouble(Console.ReadLine());

        double discountPercentage = 0;

        switch (customerType)
        {
            case 'R':
                if (purchaseAmount > 100)
                    discountPercentage = 5;
                break;

            case 'P':
                discountPercentage = 10;
                break;

            case 'V':
                discountPercentage = 15;

                if (purchaseAmount > 200)
                    discountPercentage += 5;
                break;

            default:
                Console.WriteLine("Invalid Customer Type");
                return;
        }

        double discountAmount = purchaseAmount * discountPercentage / 100;
        double finalPrice = purchaseAmount - discountAmount;

        Console.WriteLine("\n===== BILL DETAILS =====");
        Console.WriteLine($"Original Price  : {purchaseAmount:C}");
        Console.WriteLine($"Discount ({discountPercentage}%) : {discountAmount:C}");
        Console.WriteLine($"Final Price     : {finalPrice:C}");
    }
}