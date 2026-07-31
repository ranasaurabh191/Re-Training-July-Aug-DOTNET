namespace Day1_PayrollCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();

            Console.Write("Enter Employee Name: ");
            employee.Name = Console.ReadLine() ?? "";

            Console.Write("Enter Hours Worked: ");
            if (!double.TryParse(Console.ReadLine(), out double hours) || hours < 0 || hours > 168)
            {
                Console.WriteLine("Invalid Hours Worked.");
                return;
            }

            employee.HoursWorked = hours;

            Console.Write("Enter Hourly Rate: ");
            if (!double.TryParse(Console.ReadLine(), out double rate) || rate < 0)
            {
                Console.WriteLine("Invalid Hourly Rate.");
                return;
            }

            employee.HourlyRate = rate;

            PayrollCalculator payrollCalculator = new PayrollCalculator();

            double grossSalary = payrollCalculator.CalculateSalary(employee);

            Console.WriteLine($"Employee Name : {employee.Name}");
            Console.WriteLine($"Gross Salary  : {Math.Round(grossSalary, 2)}");
        }
    }
}