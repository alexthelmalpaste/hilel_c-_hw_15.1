using System;
using System.Collections.Generic;

public abstract class Product
{
    public string Name { get; }
    protected double BasePrice;

    public Product(string name, double basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public abstract double Price { get; }

    public override string ToString()
    {
        return $"Product: {Name}, Price: {Price}";
    }
}

public class Carrot : Product
{
    public Carrot(double basePrice) : base(name: "Carrot", basePrice) { }

    public override double Price => BasePrice;
}

public class Potato : Product
{
    public double Count { get; }

    public Potato(double basePrice, double count) : base(name: "Potato", basePrice)
    {
        Count = count;
    }

    public override double Price => BasePrice * Count;

    public override string ToString()
    {
        return $"Product: {Name}, Price: {BasePrice}, Count: {Count}, Total price: {Price}";
    }
}

public class Tomato : Product
{
    public Tomato(double basePrice) : base(name: "Tomato", basePrice) { }

    public override double Price => BasePrice;
}

public class Cucumber : Product
{
    public double Count { get; }

    public Cucumber(double basePrice, double count) : base(name: "Cucumber", basePrice)
    {
        Count = count;
    }

    public override double Price => BasePrice * Count;

    public override string ToString()
    {
        return $"Product: {Name}, Price: {BasePrice}, Count: {Count}, Total price: {Price}";
    }
}

public class VegetableShop
{
    private List<Product> products = new List<Product>();

    public void AddProducts(List<Product> newProducts)
    {
        products.AddRange(newProducts);
    }

    public void PrintProductsInfo()
    {
        double totalPrice = 0;
        foreach (var product in products)
        {
            Console.WriteLine(product);
            totalPrice += product.Price;
        }

        Console.WriteLine($"Total products price: {totalPrice}");
    }
}

class Program
{
    static void Main()
    {
        var products = new List<Product>
        {
            new Carrot(15),
            new Potato(20, 4),
            new Cucumber(14, 2)
        };

        VegetableShop shop = new VegetableShop();
        shop.AddProducts(products);

        shop.PrintProductsInfo();
    }
}
