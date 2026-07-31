namespace Day2_GeometryCalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Circle Area    : {GeometryCalculator.CalculateArea(5)}");
            Console.WriteLine($"Rectangle Area : {GeometryCalculator.CalculateArea(4, 6)}");
            Console.WriteLine($"Triangle Area  : {GeometryCalculator.CalculateArea(3, 7, true)}");
            Console.WriteLine($"Circle Area    : {GeometryCalculator.CalculateArea(radius: 5, decimals: 4)}");
        }
    }
}