
namespace BankBalanceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double openingBalance, deposits, withdrawals;

            Console.Write("Enter Opening Balance: ");
            if (!double.TryParse(Console.ReadLine(), out openingBalance) || openingBalance < 0)
            {
                Console.WriteLine("Invalid Opening Balance.");
                return;
            }

            Console.Write("Enter Total Deposits: ");
            if (!double.TryParse(Console.ReadLine(), out deposits) || deposits < 0)
            {
                Console.WriteLine("Invalid Deposit Amount.");
                return;
            }

            Console.Write("Enter Total Withdrawals: ");
            if (!double.TryParse(Console.ReadLine(), out withdrawals) || withdrawals < 0)
            {
                Console.WriteLine("Invalid Withdrawal Amount.");
                return;
            }

            double availableBalance = openingBalance + deposits;

            if (withdrawals > availableBalance)
            {
                Console.WriteLine("Error: Insufficient Balance.");
                return;
            }

            double finalBalance = availableBalance - withdrawals;

            Console.WriteLine("\n------ ACCOUNT SUMMARY ------");
            Console.WriteLine($"Opening Balance : {openingBalance}");
            Console.WriteLine($"Deposits        : {deposits}");
            Console.WriteLine($"Withdrawals     : {withdrawals}");
            Console.WriteLine($"Final Balance   : {Math.Round(finalBalance, 2)}");
        }
    }
}