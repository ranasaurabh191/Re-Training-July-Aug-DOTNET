abstract class Payment
{
    public decimal Amount { get; set; }

    protected Payment(decimal amount)
    {
        Amount = amount;
    }

    public void Validate()
    {
        Console.WriteLine("Payment Validated");
    }

    public void GenerateReceipt()
    {
        Console.WriteLine("Receipt Generated");
    }

    public abstract void Pay();
}

class CreditCardPayment : Payment
{
    public CreditCardPayment(decimal amount) : base(amount) { }

    public override void Pay()
    {
        Console.WriteLine($"Paid ₹{Amount} using Credit Card");
    }
}

class UPIPayment : Payment
{
    public UPIPayment(decimal amount) : base(amount) { }

    public override void Pay()
    {
        Console.WriteLine($"Paid ₹{Amount} using UPI");
    }
}

class NetBankingPayment : Payment
{
    public NetBankingPayment(decimal amount) : base(amount) { }

    public override void Pay()
    {
        Console.WriteLine($"Paid ₹{Amount} using Net Banking");
    }
}

class Program
{
    static void Main()
    {
        List<Payment> payments =
        [
            new CreditCardPayment(5000),
            new UPIPayment(2500),
            new NetBankingPayment(1000)
        ];

        foreach (Payment payment in payments)
        {
            payment.Validate();
            payment.Pay();
            payment.GenerateReceipt();
            Console.WriteLine();
        }
    }
}