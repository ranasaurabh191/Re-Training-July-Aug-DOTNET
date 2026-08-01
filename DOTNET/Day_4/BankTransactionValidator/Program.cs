using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Bank Transaction Validator ===");

        Console.Write("Enter Account Type (S/C): ");
        char accountType = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Enter Current Balance: ");
        double balance = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Withdrawal Amount: ");
        double withdrawal = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Transactions Today: ");
        int todayTransactions = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Transactions This Month: ");
        int monthTransactions = Convert.ToInt32(Console.ReadLine());

        string status = "Approved";
        string reason = "";

        if (withdrawal > 1000)
        {
            status = "Denied";
            reason = "Maximum withdrawal per transaction is $1000.";
        }
        else if (todayTransactions * withdrawal + withdrawal > 5000)
        {
            status = "Denied";
            reason = "Daily withdrawal limit exceeded.";
        }
        else if (balance - withdrawal < 50)
        {
            status = "Denied";
            reason = "Minimum balance of $50 must be maintained.";
        }

        if (status == "Approved")
        {
            balance -= withdrawal;

            if (accountType == 'S' && monthTransactions >= 3)
                balance -= 1;

            Console.WriteLine("\n===== TRANSACTION RESULT =====");
            Console.WriteLine($"Status      : {status}");
            Console.WriteLine($"New Balance : ${balance:F2}");
        }
        else
        {
            Console.WriteLine("\n===== TRANSACTION RESULT =====");
            Console.WriteLine($"Status : {status}");
            Console.WriteLine($"Reason : {reason}");
        }
    }
}