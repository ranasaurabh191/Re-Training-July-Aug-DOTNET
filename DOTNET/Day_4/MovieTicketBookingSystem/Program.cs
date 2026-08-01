using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Movie Ticket Booking System ===");

        Console.Write("Enter Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Show Time (24-hour format): ");
        int showTime = Convert.ToInt32(Console.ReadLine());

        Console.Write("Is Student (Y/N): ");
        char student = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Is 3D Movie (Y/N): ");
        char is3D = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Enter Number of Tickets: ");
        int tickets = Convert.ToInt32(Console.ReadLine());

        double price = 12;

        if (age < 12)
            price *= 0.70;
        else if (age >= 60)
            price *= 0.75;
        else if (student == 'Y')
            price *= 0.80;

        if (showTime < 17)
            price -= 2;
        else
            price += 3;

        if (is3D == 'Y')
            price += 5;

        double total = price * tickets;

        if (tickets >= 6)
            total *= 0.90;

        Console.WriteLine("\n===== BOOKING DETAILS =====");
        Console.WriteLine($"Price Per Ticket : ${price:F2}");
        Console.WriteLine($"Total Price      : ${total:F2}");
    }
}