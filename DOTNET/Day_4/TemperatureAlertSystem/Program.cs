using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Temperature Alert System ===");

        Console.Write("Enter Current Temperature (°C): ");
        double currentTemperature = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Previous Temperature (°C): ");
        double previousTemperature = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n===== ALERT =====");

        if (currentTemperature < 0)
        {
            Console.WriteLine("Freezing Alert! Risk of ice formation.");
        }
        else if (currentTemperature >= 0 && currentTemperature <= 10)
        {
            Console.WriteLine("Cold Alert. Wear warm clothing.");
        }
        else if (currentTemperature >= 11 && currentTemperature <= 25)
        {
            Console.WriteLine("Comfortable temperature. No alerts.");
        }
        else if (currentTemperature >= 26 && currentTemperature <= 35)
        {
            Console.WriteLine("Heat Alert. Stay hydrated.");
        }
        else
        {
            Console.WriteLine("Extreme Heat Warning! Avoid outdoor activities.");
        }

        if (Math.Abs(currentTemperature - previousTemperature) > 10)
        {
            Console.WriteLine("Rapid temperature change detected!");
        }
    }
}