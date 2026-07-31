namespace Day2_CalculatorApp
{
    static class MathOperations
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Add(params int[] numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static int Multiply(params int[] numbers)
        {
            int product = 1;

            foreach (int number in numbers)
            {
                product *= number;
            }

            return product;
        }
    }
}