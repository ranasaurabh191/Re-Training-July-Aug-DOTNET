
using PayrollSystem;

namespace PayrollSystem
{
    class PayrollCalculator
    {
        public double CalculateSalary(Employee employee)
        {
            double regularPay;
            double overtimePay = 0;

            if (employee.HoursWorked <= 40)
            {
                regularPay = employee.HoursWorked * employee.HourlyRate;
            }
            else
            {
                regularPay = 40 * employee.HourlyRate;
                overtimePay = (employee.HoursWorked - 40) * employee.HourlyRate * 1.5;
            }

            return regularPay + overtimePay;
        }
    }
}
