namespace StudentMarksCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double mark1, mark2, mark3, mark4, mark5;

            Console.Write("Enter Mark 1: ");
            if (!double.TryParse(Console.ReadLine(), out mark1) || mark1 < 0 || mark1 > 100)
            {
                Console.WriteLine("Invalid Mark 1.");
                return;
            }

            Console.Write("Enter Mark 2: ");
            if (!double.TryParse(Console.ReadLine(), out mark2) || mark2 < 0 || mark2 > 100)
            {
                Console.WriteLine("Invalid Mark 2.");
                return;
            }

            Console.Write("Enter Mark 3: ");
            if (!double.TryParse(Console.ReadLine(), out mark3) || mark3 < 0 || mark3 > 100)
            {
                Console.WriteLine("Invalid Mark 3.");
                return;
            }

            Console.Write("Enter Mark 4: ");
            if (!double.TryParse(Console.ReadLine(), out mark4) || mark4 < 0 || mark4 > 100)
            {
                Console.WriteLine("Invalid Mark 4.");
                return;
            }

            Console.Write("Enter Mark 5: ");
            if (!double.TryParse(Console.ReadLine(), out mark5) || mark5 < 0 || mark5 > 100)
            {
                Console.WriteLine("Invalid Mark 5.");
                return;
            }

            double total = mark1 + mark2 + mark3 + mark4 + mark5;
            double average = total / 5;
            double percentage = (total / 500) * 100;

            Console.WriteLine($"Total Marks : {total}");
            Console.WriteLine($"Average     : {average}");
            Console.WriteLine($"Percentage  : {Math.Round(percentage, 2)}%");
        }
    }
}