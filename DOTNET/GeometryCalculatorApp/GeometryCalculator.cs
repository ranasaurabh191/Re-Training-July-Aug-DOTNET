namespace Day2_GeometryCalculatorApp
{
    static class GeometryCalculator
    {
        public static double CalculateArea(double radius, int decimals = 2)
        {
            return Math.Round(Math.PI * radius * radius, decimals);
        }

        public static double CalculateArea(int length, int width)
        {
            return length * width;
        }

        public static double CalculateArea(int @base, int height, bool triangle)
        {
            return 0.5 * @base * height;
        }
    }
}