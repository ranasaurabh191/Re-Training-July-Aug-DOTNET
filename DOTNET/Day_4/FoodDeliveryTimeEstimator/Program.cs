using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Food Delivery Time Estimator ===");

        Console.Write("Enter Distance (km): ");
        double distance = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Weather (R/S/C): ");
        char weather = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Enter Current Hour (0-23): ");
        int hour = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Preparation Time (minutes): ");
        int prepTime = Convert.ToInt32(Console.ReadLine());

        int totalTime = 30 + prepTime;

        if (distance > 5)
            totalTime += (int)((distance - 5) * 2);

        switch (weather)
        {
            case 'R':
                totalTime += 10;
                break;

            case 'S':
                totalTime += 20;
                break;

            case 'C':
                break;

            default:
                Console.WriteLine("Invalid Weather");
                return;
        }

        if (hour >= 17 && hour <= 20)
            totalTime += 15;

        Console.WriteLine("\n===== DELIVERY ESTIMATE =====");
        Console.WriteLine($"Estimated Delivery Time : {totalTime} minutes");
    }
}