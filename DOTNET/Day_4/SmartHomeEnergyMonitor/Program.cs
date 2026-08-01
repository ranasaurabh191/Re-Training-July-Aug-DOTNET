using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Smart Home Energy Monitor ===");

        Console.Write("Enter Lights Usage (hours): ");
        double lights = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter AC Usage (hours): ");
        double ac = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter TV Usage (hours): ");
        double tv = Convert.ToDouble(Console.ReadLine());

        double lightCost = lights * 0.1 * 0.15;
        double acCost = ac * 1.5 * 0.15;
        double tvCost = tv * 0.3 * 0.15;

        double total = lightCost + acCost + tvCost;

        Console.WriteLine("\n===== ENERGY REPORT =====");
        Console.WriteLine($"Lights Cost : ${lightCost:F2}");
        Console.WriteLine($"AC Cost     : ${acCost:F2}");
        Console.WriteLine($"TV Cost     : ${tvCost:F2}");
        Console.WriteLine($"Total Cost  : ${total:F2}");

        Console.WriteLine();

        if (lights > 10)
            Console.WriteLine("Alert: Lights usage exceeds recommended hours.");

        if (ac > 8)
            Console.WriteLine("Alert: AC usage exceeds recommended hours.");

        if (tv > 6)
            Console.WriteLine("Alert: TV usage exceeds recommended hours.");

        if (total > 5)
            Console.WriteLine("Suggestion: Reduce appliance usage to save energy costs.");
    }
}