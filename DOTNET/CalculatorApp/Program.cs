namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MathOperations.Add(5, 10));
            Console.WriteLine(MathOperations.Add(1, 2, 3, 4, 5));

            Console.WriteLine(MathOperations.Multiply(2, 3));
            Console.WriteLine(MathOperations.Multiply(2, 3, 4, 5));
        }
    }
}