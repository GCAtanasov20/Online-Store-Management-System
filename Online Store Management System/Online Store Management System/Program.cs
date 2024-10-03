public class Program
{
    public static void Main()
    {
        ICustomer customer = new Customer("John", "Doe");

        PhysicalProduct laptop = new PhysicalProduct("Laptop", 1000.00m, 5);
        PhysicalProduct smartphone = new PhysicalProduct("Smartphone", 700.00m, 2);

        laptop.OnOutOfStock += message => Console.WriteLine($"[EVENT] {message}");
        smartphone.OnOutOfStock += message => Console.WriteLine($"[EVENT] {message}");

        IOrder laptopOrder = new PhysicalProductOrder();
        IOrder smartphoneOrder = new PhysicalProductOrder();

        if (laptopOrder.CreateOrder(customer, laptop, 3))
        {
            laptopOrder.ApplyDiscount(new PercentageDiscount(10));
            laptopOrder.CompleteOrder();
        }
        Console.WriteLine();

        if (smartphoneOrder.CreateOrder(customer, smartphone, 2))
        {
            smartphoneOrder.ApplyDiscount(new FixedDiscount(50));
            smartphoneOrder.CompleteOrder();
        }
        Console.WriteLine();

        if (!laptopOrder.CreateOrder(customer, laptop, 3))
        {
            Console.WriteLine("Failed to create second laptop order due to insufficient stock");
        }
    }
}
