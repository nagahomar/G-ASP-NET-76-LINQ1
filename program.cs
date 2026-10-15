
using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}

class Order
{
    public string CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
}

class Customer
{
    public string CustomerID { get; set; }
    public List<Order> Orders { get; set; }
}

class Program
{
    static void Main()
    {
        List<Product> ProductList = new List<Product>
        {
            new Product { ProductName = "Chai", Category = "Beverages", UnitPrice = 18, UnitsInStock = 39 },
            new Product { ProductName = "Chang", Category = "Beverages", UnitPrice = 19, UnitsInStock = 17 },
            new Product { ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10, UnitsInStock = 13 },
            new Product { ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22, UnitsInStock = 53 },
            new Product { ProductName = "Ikura", Category = "Seafood", UnitPrice = 31, UnitsInStock = 20 },
            new Product { ProductName = "Konbu", Category = "Seafood", UnitPrice = 6, UnitsInStock = 24 },
            new Product { ProductName = "Salmon", Category = "Seafood", UnitPrice = 25, UnitsInStock = 12 }
        };

        List<Customer> CustomerList = new List<Customer>
        {
            new Customer
            {
                CustomerID = "ALFKI",
                Orders = new List<Order>
                {
                    new Order { CustomerID = "ALFKI", OrderDate = new DateTime(1997, 5, 10) },
                    new Order { CustomerID = "ALFKI", OrderDate = new DateTime(1996, 3, 15) }
                }
            },
            new Customer
            {
                CustomerID = "ANATR",
                Orders = new List<Order>
                {
                    new Order { CustomerID = "ANATR", OrderDate = new DateTime(1998, 7, 20) }
                }
            }
        };

        var q1 = ProductList
            .Where(p => p.Category == "Seafood")
            .Select(p => new { p.ProductName, p.UnitPrice });

        foreach (var p in q1)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        var q2 = ProductList.Select(p => p.ProductName);

        foreach (var name in q2)
            Console.WriteLine(name);

        var q3 = ProductList.OrderBy(p => p.UnitPrice);

        foreach (var p in q3)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        var q4 = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);

        foreach (var p in q4)
            Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

        var q5 = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

        foreach (var p in q5)
            Console.WriteLine(p.ProductName);

        var q6 = ProductList.Select(p => new
        {
            Name = p.ProductName,
            Price = p.UnitPrice,
            StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
        });

        foreach (var p in q6)
            Console.WriteLine($"{p.Name} - {p.Price} - {p.StockStatus}");

        var q7 = ProductList.Select((p, index) => new
        {
            Position = index + 1,
            p.ProductName
        });

        foreach (var p in q7)
            Console.WriteLine($"{p.Position}. {p.ProductName}");

        var q8 = ProductList
            .OrderBy(p => p.Category)
            .ThenByDescending(p => p.UnitPrice);

        foreach (var p in q8)
            Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice}");

        var q9 = ProductList
            .Where(p => p.Category == "Beverages")
            .OrderByDescending(p => p.UnitsInStock)
            .Select(p => new { p.ProductName, p.UnitsInStock });

        foreach (var p in q9)
            Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");

        var q10 =
            from c in CustomerList
            from o in c.Orders
            where o.OrderDate >= new DateTime(1997, 1, 1)
            select new
            {
                CustomerID = c.CustomerID,
                o.OrderDate
            };

        foreach (var o in q10)
            Console.WriteLine($"{o.CustomerID} - {o.OrderDate:d}");

        var q11 = ProductList.Select((p, index) => new
        {
            Position = index + 1,
            p.ProductName
        });

        foreach (var p in q11)
            Console.WriteLine($"{p.Position} - {p.ProductName}");

        string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

        var q12 = Arr
            .OrderBy(word => word.Length)
            .ThenBy(word => word, StringComparer.OrdinalIgnoreCase);

        foreach (var word in q12)
            Console.WriteLine(word);

        var q13 = Arr
            .Where(word => word.Length > 1 && char.ToLowerInvariant(word[1]) == 'i')
            .Reverse();

        foreach (var word in q13)
            Console.WriteLine(word);
    }
}
```
