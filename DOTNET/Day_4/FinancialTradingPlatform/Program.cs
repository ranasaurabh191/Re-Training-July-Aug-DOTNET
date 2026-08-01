using System;
using System.Collections.Generic;
using System.Linq;

class Order
{
    public int OrderId { get; set; }
    public string Trader { get; set; }
    public string Type { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"Order ID : {OrderId}\nTrader   : {Trader}\nType     : {Type}\nPrice    : {Price}\nQuantity : {Quantity}\n";
    }
}

class Program
{
    static Dictionary<int, Order> orderLookup = new Dictionary<int, Order>();

    static SortedDictionary<double, List<Order>> buyOrders =
        new SortedDictionary<double, List<Order>>(Comparer<double>.Create((x, y) => y.CompareTo(x)));

    static SortedDictionary<double, List<Order>> sellOrders =
        new SortedDictionary<double, List<Order>>();

    static SortedList<double, List<Order>> stopLossOrders =
        new SortedList<double, List<Order>>();

    static List<Order> orderHistory = new List<Order>();

    static void AddOrder()
    {
        Order order = new Order();

        Console.Write("Order Id : ");
        order.OrderId = int.Parse(Console.ReadLine());

        Console.Write("Trader Name : ");
        order.Trader = Console.ReadLine();

        Console.Write("Order Type (Buy/Sell) : ");
        order.Type = Console.ReadLine();

        Console.Write("Price : ");
        order.Price = double.Parse(Console.ReadLine());

        Console.Write("Quantity : ");
        order.Quantity = int.Parse(Console.ReadLine());

        orderLookup[order.OrderId] = order;

        if (order.Type.Equals("Buy", StringComparison.OrdinalIgnoreCase))
        {
            if (!buyOrders.ContainsKey(order.Price))
                buyOrders.Add(order.Price, new List<Order>());

            buyOrders[order.Price].Add(order);
        }
        else
        {
            if (!sellOrders.ContainsKey(order.Price))
                sellOrders.Add(order.Price, new List<Order>());

            sellOrders[order.Price].Add(order);
        }

        Console.Write("Stop Loss Price (0 if none) : ");
        double stop = double.Parse(Console.ReadLine());

        if (stop > 0)
        {
            if (!stopLossOrders.ContainsKey(stop))
                stopLossOrders.Add(stop, new List<Order>());

            stopLossOrders[stop].Add(order);
        }

        orderHistory.Add(order);

        Console.WriteLine("Order Added Successfully");
    }

    static void SearchOrder()
    {
        Console.Write("Enter Order Id : ");
        int id = int.Parse(Console.ReadLine());

        if (orderLookup.ContainsKey(id))
            Console.WriteLine(orderLookup[id]);
        else
            Console.WriteLine("Order Not Found");
    }

    static void DisplayBuyOrders()
    {
        foreach (var item in buyOrders)
        {
            Console.WriteLine("Price : " + item.Key);

            foreach (var order in item.Value)
                Console.WriteLine(order);
        }
    }

    static void DisplaySellOrders()
    {
        foreach (var item in sellOrders)
        {
            Console.WriteLine("Price : " + item.Key);

            foreach (var order in item.Value)
                Console.WriteLine(order);
        }
    }

    static void TriggerStopLoss()
    {
        Console.Write("Current Market Price : ");
        double marketPrice = double.Parse(Console.ReadLine());

        foreach (var item in stopLossOrders)
        {
            if (item.Key <= marketPrice)
            {
                Console.WriteLine("Triggered Stop Loss : " + item.Key);

                foreach (var order in item.Value)
                    Console.WriteLine(order);
            }
        }
    }

    static void ShowMarketDepth()
    {
        Console.WriteLine("\nBUY ORDERS");

        foreach (var item in buyOrders)
        {
            int total = item.Value.Sum(x => x.Quantity);
            Console.WriteLine($"Price : {item.Key}  Volume : {total}");
        }

        Console.WriteLine("\nSELL ORDERS");

        foreach (var item in sellOrders)
        {
            int total = item.Value.Sum(x => x.Quantity);
            Console.WriteLine($"Price : {item.Key}  Volume : {total}");
        }
    }

    static void DisplayHistory()
    {
        foreach (var order in orderHistory)
            Console.WriteLine(order);
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== FINANCIAL TRADING PLATFORM =====");
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. Search Order");
            Console.WriteLine("3. Display Buy Orders");
            Console.WriteLine("4. Display Sell Orders");
            Console.WriteLine("5. Trigger Stop Loss");
            Console.WriteLine("6. Show Market Depth");
            Console.WriteLine("7. Order History");
            Console.WriteLine("8. Exit");

            Console.Write("Enter Choice : ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddOrder();
                    break;

                case 2:
                    SearchOrder();
                    break;

                case 3:
                    DisplayBuyOrders();
                    break;

                case 4:
                    DisplaySellOrders();
                    break;

                case 5:
                    TriggerStopLoss();
                    break;

                case 6:
                    ShowMarketDepth();
                    break;

                case 7:
                    DisplayHistory();
                    break;

                case 8:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}