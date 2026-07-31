
namespace Day1_WarehouseVolumeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double length, width, height;

            Console.Write("Enter Length: ");
            if (!double.TryParse(Console.ReadLine(), out length) || length <= 0)
            {
                Console.WriteLine("Invalid Length.");
                return;
            }

            Console.Write("Enter Width: ");
            if (!double.TryParse(Console.ReadLine(), out width) || width <= 0)
            {
                Console.WriteLine("Invalid Width.");
                return;
            }

            Console.Write("Enter Height: ");
            if (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
            {
                Console.WriteLine("Invalid Height.");
                return;
            }

            double volume = length * width * height;

            Console.WriteLine("\n------ PACKAGE DETAILS ------");
            Console.WriteLine($"Length : {length}");
            Console.WriteLine($"Width  : {width}");
            Console.WriteLine($"Height : {height}");
            Console.WriteLine($"Volume : {Math.Round(volume, 2)} cubic units");
        }
    }
}