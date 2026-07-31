namespace Day1_HospitalRegistrationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Patient patient = new Patient();

            patient.Age = Validation.ReadAge();
            patient.Weight = Validation.ReadWeight();
            patient.Height = Validation.ReadHeight();
            patient.Temperature = Validation.ReadTemperature();

            double bmi = patient.Weight / (patient.Height * patient.Height);

            Console.WriteLine("\nPatient Summary");
            Console.WriteLine($"Age         : {patient.Age}");
            Console.WriteLine($"Weight      : {patient.Weight} kg");
            Console.WriteLine($"Height      : {patient.Height} m");
            Console.WriteLine($"Temperature : {patient.Temperature} °C");
            Console.WriteLine($"BMI         : {System.Math.Round(bmi, 2)}");
        }
    }
}