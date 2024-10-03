public interface IDiscount
{
    decimal ApplyDiscount(decimal price);
}

public class FixedDiscount : IDiscount
{
    public decimal Amount { get; set; }

    public FixedDiscount(decimal amount)
    {
        Amount = amount;
    }

    public decimal ApplyDiscount(decimal price)
    {
        return price - Amount;
    }
}

public class PercentageDiscount : IDiscount
{
    public decimal Percentage { get; set; }

    public PercentageDiscount(decimal percentage)
    {
        Percentage = percentage;
    }

    public decimal ApplyDiscount(decimal price)
    {
        return price - (price * (Percentage / 100));
    }
}
