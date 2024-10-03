using System;

public abstract class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public event Action<string> OnOutOfStock;

    public Product(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }

    public abstract void DisplayProductDetails();

    public bool ValidateStock(int quantity)
    {
        return Stock >= quantity;
    }

    public void DeductStock(int quantity)
    {
        Stock -= quantity;
        if (Stock <= 0)
        {
            Stock = 0;
            OnOutOfStock?.Invoke($"{Name} is out of stock!");
        }
    }
}

public class PhysicalProduct : Product
{
    public PhysicalProduct(string name, decimal price, int stock)
        : base(name, price, stock) { }

    public override void DisplayProductDetails()
    {
        Console.WriteLine($"Physical Product: {Name}, Price: {Price}, Stock: {Stock}");
    }
}

public class DigitalProduct : Product
{
    public DigitalProduct(string name, decimal price, int stock)
        : base(name, price, stock) { }

    public override void DisplayProductDetails()
    {
        Console.WriteLine($"Digital Product: {Name}, Price: {Price}, Stock: Unlimited (digital)");
    }
}
