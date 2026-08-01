using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Parking Fee Calculator ===");

        Console.Write("Enter Vehicle Type (C/M/T): ");
        char vehicleType = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Enter Parking Hours: ");
        double hours = Convert.ToDouble(Console.ReadLine());

        double rate = 0;
        double maxFee = 0;

        switch (vehicleType)
        {
            case 'C':
                rate = 3;
                maxFee = 25;
                break;

            case 'M':
                rate = 2;
                maxFee = 15;
                break;

            case 'T':
                rate = 5;
                maxFee = 40;
                break;

            default:
                Console.WriteLine("Invalid Vehicle Type");
                return;
        }

        double fee;

        if (hours <= 0.5)
        {
            fee = 0;
        }
        else
        {
            fee = Math.Ceiling(hours) * rate;

            if (fee > maxFee)
                fee = maxFee;

            if (hours > 8)
                fee -= fee * 0.10;
        }

        Console.WriteLine("\n===== PARKING DETAILS =====");
        Console.WriteLine($"Vehicle Type : {vehicleType}");
        Console.WriteLine($"Parking Hours: {hours}");
        Console.WriteLine($"Parking Fee  : ${fee:F2}");
    }
}