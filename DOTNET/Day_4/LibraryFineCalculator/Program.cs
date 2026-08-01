using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Library Fine Calculator ===");

        Console.Write("Enter Item Type (B/D/J): ");
        char itemType = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Enter Days Late: ");
        int daysLate = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter User Type (S/R): ");
        char userType = Convert.ToChar(Console.ReadLine().ToUpper());

        double rate = 0;

        switch (itemType)
        {
            case 'B':
                rate = 0.50;
                break;

            case 'D':
                rate = 1.00;
                break;

            case 'J':
                rate = 0.25;
                break;

            default:
                Console.WriteLine("Invalid Item Type");
                return;
        }

        double fine = 0;

        if (daysLate > 3)
        {
            fine = (daysLate - 3) * rate;

            if (fine > 20)
                fine = 20;

            if (userType == 'S')
                fine *= 0.5;
        }

        Console.WriteLine("\n===== FINE DETAILS =====");
        Console.WriteLine($"Item Type : {itemType}");
        Console.WriteLine($"Days Late : {daysLate}");
        Console.WriteLine($"Fine      : ${fine:F2}");
    }
}