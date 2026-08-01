using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public double Rating { get; set; }
    public int Popularity { get; set; }
    public int Stock { get; set; }

    public override string ToString()
    {
        return $"Product ID : {ProductId}\nName       : {ProductName}\nCategory   : {Category}\nPrice      : {Price}\nRating     : {Rating}\nPopularity : {Popularity}\nStock      : {Stock}\n";
    }
}

class Program
{
    static Dictionary<int, Product> productLookup = new Dictionary<int, Product>();

    static Dictionary<string, List<int>> userHistory = new Dictionary<string, List<int>>();

    static SortedDictionary<double, List<Product>> productsByPrice =
        new SortedDictionary<double, List<Product>>();

    static SortedList<string, List<Product>> categoryProducts =
        new SortedList<string, List<Product>>();

    static void AddProduct()
    {
        Product product = new Product();

        Console.Write("Product Id : ");
        product.ProductId = int.Parse(Console.ReadLine());

        Console.Write("Product Name : ");
        product.ProductName = Console.ReadLine();

        Console.Write("Category : ");
        product.Category = Console.ReadLine();

        Console.Write("Price : ");
        product.Price = double.Parse(Console.ReadLine());

        Console.Write("Rating : ");
        product.Rating = double.Parse(Console.ReadLine());

        Console.Write("Popularity : ");
        product.Popularity = int.Parse(Console.ReadLine());

        Console.Write("Stock : ");
        product.Stock = int.Parse(Console.ReadLine());

        productLookup[product.ProductId] = product;

        if (!productsByPrice.ContainsKey(product.Price))
            productsByPrice.Add(product.Price, new List<Product>());

        productsByPrice[product.Price].Add(product);

        if (!categoryProducts.ContainsKey(product.Category))
            categoryProducts.Add(product.Category, new List<Product>());

        categoryProducts[product.Category].Add(product);

        categoryProducts[product.Category] = categoryProducts[product.Category]
            .OrderByDescending(x => x.Rating)
            .ToList();

        Console.WriteLine("Product Added Successfully");
    }

    static void ViewProduct()
    {
        Console.Write("User Name : ");
        string user = Console.ReadLine();

        Console.Write("Product Id : ");
        int id = int.Parse(Console.ReadLine());

        if (!productLookup.ContainsKey(id))
        {
            Console.WriteLine("Product Not Found");
            return;
        }

        Console.WriteLine(productLookup[id]);

        if (!userHistory.ContainsKey(user))
            userHistory.Add(user, new List<int>());

        userHistory[user].Add(id);
    }

    static void SearchProduct()
    {
        Console.Write("Product Id : ");
        int id = int.Parse(Console.ReadLine());

        if (productLookup.ContainsKey(id))
            Console.WriteLine(productLookup[id]);
        else
            Console.WriteLine("Product Not Found");
    }

    static void DisplayPriceWise()
    {
        foreach (var item in productsByPrice)
        {
            Console.WriteLine("Price : " + item.Key);

            foreach (var product in item.Value)
                Console.WriteLine(product);
        }
    }

    static void DisplayCategoryWise()
    {
        foreach (var item in categoryProducts)
        {
            Console.WriteLine("\nCategory : " + item.Key);

            foreach (var product in item.Value)
                Console.WriteLine(product);
        }
    }

    static void RecommendProducts()
    {
        Console.Write("User Name : ");
        string user = Console.ReadLine();

        if (!userHistory.ContainsKey(user))
        {
            Console.WriteLine("No History Available");
            return;
        }

        int lastProduct = userHistory[user].Last();

        string category = productLookup[lastProduct].Category;

        var recommendations = categoryProducts[category]
            .OrderByDescending(x => x.Popularity)
            .ThenBy(x => x.Price)
            .ThenByDescending(x => x.Rating);

        Console.WriteLine("\nRecommended Products");

        foreach (var product in recommendations)
            Console.WriteLine(product);
    }

    static void UpdateStock()
    {
        Console.Write("Product Id : ");
        int id = int.Parse(Console.ReadLine());

        if (!productLookup.ContainsKey(id))
        {
            Console.WriteLine("Product Not Found");
            return;
        }

        Console.Write("New Stock : ");
        productLookup[id].Stock = int.Parse(Console.ReadLine());

        Console.WriteLine("Stock Updated");
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== E-COMMERCE RECOMMENDATION ENGINE =====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Product");
            Console.WriteLine("3. Search Product");
            Console.WriteLine("4. Display Products By Price");
            Console.WriteLine("5. Display Category Wise");
            Console.WriteLine("6. Recommend Products");
            Console.WriteLine("7. Update Stock");
            Console.WriteLine("8. Exit");

            Console.Write("Enter Choice : ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    ViewProduct();
                    break;
                case 3:
                    SearchProduct();
                    break;
                case 4:
                    DisplayPriceWise();
                    break;
                case 5:
                    DisplayCategoryWise();
                    break;
                case 6:
                    RecommendProducts();
                    break;
                case 7:
                    UpdateStock();
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