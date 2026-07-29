namespace BMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight, height;

            Console.Write("Enter Weight (kg): ");
            if (!double.TryParse(Console.ReadLine(), out weight) || weight <= 0)
            {
                Console.WriteLine("Invalid Weight.");
                return;
            }

            Console.Write("Enter Height (meters): ");
            if (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
            {
                Console.WriteLine("Invalid Height.");
                return;
            }

            double bmi = weight / (height * height);

            Console.WriteLine("\n------ BMI REPORT ------");
            Console.WriteLine($"BMI : {Math.Round(bmi, 2)}");

            if (bmi < 18.5) Console.WriteLine("Category : Underweight");
            else if (bmi < 25) Console.WriteLine("Category : Normal Weight");
            else if (bmi < 30) Console.WriteLine("Category : Overweight");
            else Console.WriteLine("Category : Obese");
        }
    }
}