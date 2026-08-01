using System;
using System.Collections.Generic;
using System.Linq;

class Package
{
    public int PackageId { get; set; }
    public string CustomerName { get; set; }
    public string Location { get; set; }
    public string DriverName { get; set; }
    public int Priority { get; set; }
    public DateTime DeliveryTime { get; set; }
    public string Status { get; set; }

    public override string ToString()
    {
        return $"Package ID : {PackageId}\nCustomer   : {CustomerName}\nLocation   : {Location}\nDriver     : {DriverName}\nPriority   : {Priority}\nDelivery   : {DeliveryTime}\nStatus     : {Status}\n";
    }
}

class Program
{
    static Dictionary<int, Package> packageLookup = new Dictionary<int, Package>();

    static SortedDictionary<DateTime, List<Package>> deliverySchedule =
        new SortedDictionary<DateTime, List<Package>>();

    static SortedList<string, List<Package>> locationPackages =
        new SortedList<string, List<Package>>();

    static List<Package> deliverySequence = new List<Package>();

    static void AddPackage()
    {
        Package package = new Package();

        Console.Write("Package Id : ");
        package.PackageId = int.Parse(Console.ReadLine());

        Console.Write("Customer Name : ");
        package.CustomerName = Console.ReadLine();

        Console.Write("Location : ");
        package.Location = Console.ReadLine();

        Console.Write("Driver Name : ");
        package.DriverName = Console.ReadLine();

        Console.Write("Priority : ");
        package.Priority = int.Parse(Console.ReadLine());

        Console.Write("Delivery Time (yyyy-MM-dd HH:mm) : ");
        package.DeliveryTime = DateTime.Parse(Console.ReadLine());

        package.Status = "Pending";

        packageLookup[package.PackageId] = package;

        if (!deliverySchedule.ContainsKey(package.DeliveryTime))
            deliverySchedule.Add(package.DeliveryTime, new List<Package>());

        deliverySchedule[package.DeliveryTime].Add(package);

        if (!locationPackages.ContainsKey(package.Location))
            locationPackages.Add(package.Location, new List<Package>());

        locationPackages[package.Location].Add(package);

        locationPackages[package.Location] = locationPackages[package.Location]
            .OrderByDescending(x => x.Priority)
            .ToList();

        deliverySequence.Add(package);

        Console.WriteLine("Package Added Successfully");
    }

    static void SearchPackage()
    {
        Console.Write("Package Id : ");
        int id = int.Parse(Console.ReadLine());

        if (packageLookup.ContainsKey(id))
            Console.WriteLine(packageLookup[id]);
        else
            Console.WriteLine("Package Not Found");
    }

    static void UpdateStatus()
    {
        Console.Write("Package Id : ");
        int id = int.Parse(Console.ReadLine());

        if (!packageLookup.ContainsKey(id))
        {
            Console.WriteLine("Package Not Found");
            return;
        }

        Console.Write("New Status : ");
        packageLookup[id].Status = Console.ReadLine();

        Console.WriteLine("Status Updated");
    }

    static void DisplayDeliverySchedule()
    {
        foreach (var item in deliverySchedule)
        {
            Console.WriteLine("\nDelivery Time : " + item.Key);

            foreach (var package in item.Value.OrderByDescending(x => x.Priority))
                Console.WriteLine(package);
        }
    }

    static void DisplayLocationWise()
    {
        foreach (var item in locationPackages)
        {
            Console.WriteLine("\nLocation : " + item.Key);

            foreach (var package in item.Value)
                Console.WriteLine(package);
        }
    }

    static void DisplayDeliverySequence()
    {
        foreach (var package in deliverySequence)
            Console.WriteLine(package);
    }

    static void DelayedPackages()
    {
        var delayed = packageLookup.Values
            .Where(x => x.DeliveryTime < DateTime.Now && x.Status != "Delivered")
            .OrderBy(x => x.DeliveryTime);

        Console.WriteLine("\nDelayed Packages");

        foreach (var package in delayed)
            Console.WriteLine(package);
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== LOGISTICS & DELIVERY SYSTEM =====");
            Console.WriteLine("1. Add Package");
            Console.WriteLine("2. Search Package");
            Console.WriteLine("3. Update Status");
            Console.WriteLine("4. Display Delivery Schedule");
            Console.WriteLine("5. Display Location Wise");
            Console.WriteLine("6. Display Delivery Sequence");
            Console.WriteLine("7. Delayed Packages");
            Console.WriteLine("8. Exit");

            Console.Write("Enter Choice : ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddPackage();
                    break;

                case 2:
                    SearchPackage();
                    break;

                case 3:
                    UpdateStatus();
                    break;

                case 4:
                    DisplayDeliverySchedule();
                    break;

                case 5:
                    DisplayLocationWise();
                    break;

                case 6:
                    DisplayDeliverySequence();
                    break;

                case 7:
                    DelayedPackages();
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