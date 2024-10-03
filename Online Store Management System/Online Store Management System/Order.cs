public interface IOrder
{
    bool CreateOrder(ICustomer customer, Product product, int quantity);
    void ApplyDiscount(IDiscount discount);
    void CompleteOrder();
}

public abstract class Order : IOrder
{
    protected ICustomer Customer;
    protected Product Product;
    protected int Quantity;
    protected decimal TotalPrice;
    protected IDiscount Discount;

    public abstract bool CreateOrder(ICustomer customer, Product product, int quantity);

    public void ApplyDiscount(IDiscount discount)
    {
        Discount = discount;
        TotalPrice = Discount.ApplyDiscount(TotalPrice);
    }

    public abstract void CompleteOrder();
}

public class PhysicalProductOrder : Order
{
    public override bool CreateOrder(ICustomer customer, Product product, int quantity)
    {
        if (product.ValidateStock(quantity))
        {
            Customer = customer;
            Product = product;
            Quantity = quantity;
            TotalPrice = product.Price * quantity;
            Console.WriteLine($"Order created: {quantity} x {product.Name} for {customer.FirstName} {customer.LastName}");
            return true;
        }
        Console.WriteLine("Insufficient stock for the product.");
        return false;
    }

    public override void CompleteOrder()
    {
        Product.DeductStock(Quantity);
        Console.WriteLine($"Order completed. Total Price after discount: {TotalPrice:C}");
    }
}
