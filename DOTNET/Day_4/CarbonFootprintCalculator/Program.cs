using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Carbon Footprint Calculator ===");

        Console.Write("Enter Transportation Mode (C/B/T/W): ");
        char mode = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Enter Daily Distance (km): ");
        double distance = Convert.ToDouble(Console.ReadLine());

        Console.Write("Electricity Used? (Y/N): ");
        char electricity = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Diet Type (V/N): ");
        char diet = Convert.ToChar(Console.ReadLine().ToUpper());

        double carbon = 0;

        switch (mode)
        {
            case 'C':
                carbon += distance * 0.20;
                break;

            case 'B':
                carbon += distance * 0.05;
                break;

            case 'T':
                carbon += distance * 0.03;
                break;

            case 'W':
                carbon += 0;
                break;

            default:
                Console.WriteLine("Invalid Transportation Mode");
                return;
        }

        if (electricity == 'Y')
            carbon += 2;

        if (diet == 'N')
            carbon += 1.5;
        else if (diet == 'V')
            carbon += 0.8;
        else
        {
            Console.WriteLine("Invalid Diet Type");
            return;
        }

        string rating;

        if (carbon < 5)
            rating = "Low";
        else if (carbon < 10)
            rating = "Medium";
        else
            rating = "High";

        Console.WriteLine("\n===== RESULT =====");
        Console.WriteLine($"Daily Carbon Footprint : {carbon:F2} kg CO2");
        Console.WriteLine($"Environmental Rating   : {rating}");
    }
}