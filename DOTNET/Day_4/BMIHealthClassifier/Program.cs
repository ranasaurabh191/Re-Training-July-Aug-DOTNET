using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== BMI Health Classifier ===");

        Console.Write("Enter Weight (kg): ");
        double weight = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Height (m): ");
        double height = Convert.ToDouble(Console.ReadLine());

        Console.Write("Is Athlete (Y/N): ");
        char athlete = Convert.ToChar(Console.ReadLine().ToUpper());

        double bmi = weight / (height * height);

        string category;
        string recommendation = "";

        if (bmi < 18.5)
        {
            category = "Underweight";
            recommendation = "Increase your weight to reach the normal BMI range.";
        }
        else if (bmi < 25)
        {
            category = "Normal";
            recommendation = "Maintain your current lifestyle.";
        }
        else if (bmi < 30)
        {
            category = "Overweight";
            recommendation = "Consider reducing weight through diet and exercise.";
        }
        else
        {
            category = "Obese";
            recommendation = "Medical advice and a structured fitness plan are recommended.";
        }

        Console.WriteLine("\n===== RESULT =====");
        Console.WriteLine($"BMI                : {bmi:F2}");
        Console.WriteLine($"Classification     : {category}");

        if (athlete == 'Y')
            Console.WriteLine("Note               : BMI may not accurately reflect body fat for athletes.");

        Console.WriteLine($"Recommendation     : {recommendation}");
    }
}