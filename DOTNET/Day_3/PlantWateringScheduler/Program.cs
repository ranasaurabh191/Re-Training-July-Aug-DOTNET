using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Plant Watering Scheduler ===");

        Console.Write("Enter Plant Type (Cactus/Fern/Rose/Tomato): ");
        string plant = Console.ReadLine().ToLower();

        Console.Write("Enter Season (Summer/Winter/Other): ");
        string season = Console.ReadLine().ToLower();

        Console.Write("Enter Humidity (%): ");
        double humidity = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Soil Type (Clay/Sandy/Normal): ");
        string soil = Console.ReadLine().ToLower();

        double interval = 0;

        switch (plant)
        {
            case "cactus":
                interval = 14;
                break;
            case "fern":
                interval = 3;
                break;
            case "rose":
                interval = 5;
                break;
            case "tomato":
                interval = 2;
                break;
            default:
                Console.WriteLine("Invalid Plant Type");
                return;
        }

        if (season == "summer")
            interval *= 0.8;
        else if (season == "winter")
            interval *= 1.3;

        if (humidity > 60)
            interval *= 1.15;

        if (soil == "clay")
            interval += 1;
        else if (soil == "sandy")
            interval -= 1;

        if (interval < 1)
            interval = 1;

        DateTime nextWatering = DateTime.Today.AddDays(interval);

        Console.WriteLine("\n===== WATERING SCHEDULE =====");
        Console.WriteLine($"Watering Interval : {interval:F1} days");
        Console.WriteLine($"Next Watering Date: {nextWatering:dd-MM-yyyy}");
    }
}