using System;

class Program
{
    static int SumIntegers(object[] values)
    {
        int sum = 0;

        foreach (object value in values)
        {
            if (value is int x)
            {
                sum += x;
            }
        }

        return sum;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        object[] values = new object[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter value {i + 1}: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int intValue))
                values[i] = intValue;
            else if (bool.TryParse(input, out bool boolValue))
                values[i] = boolValue;
            else if (input.ToLower() == "null")
                values[i] = null;
            else
                values[i] = input;
        }

        Console.WriteLine("Sum = " + SumIntegers(values));
    }
}