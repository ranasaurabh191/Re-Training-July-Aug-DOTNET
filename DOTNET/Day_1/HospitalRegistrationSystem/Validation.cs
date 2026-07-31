namespace Day1_HospitalRegistrationSystem
{
    class Validation
    {
        public static int ReadAge()
        {
            int age;
            while (true)
            {
                Console.Write("Enter Age: ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                    return age;

                Console.WriteLine("Invalid Age.");
            }
        }

        public static double ReadWeight()
        {
            double weight;
            while (true)
            {
                Console.Write("Enter Weight (kg): ");
                if (double.TryParse(Console.ReadLine(), out weight) && weight > 0)
                    return weight;

                Console.WriteLine("Invalid Weight.");
            }
        }

        public static double ReadHeight()
        {
            double height;
            while (true)
            {
                Console.Write("Enter Height (m): ");
                if (double.TryParse(Console.ReadLine(), out height) && height > 0)
                    return height;

                Console.WriteLine("Invalid Height.");
            }
        }

        public static double ReadTemperature()
        {
            double temperature;
            while (true)
            {
                Console.Write("Enter Temperature (°C): ");
                if (double.TryParse(Console.ReadLine(), out temperature))
                    return temperature;

                Console.WriteLine("Invalid Temperature.");
            }
        }
    }
}