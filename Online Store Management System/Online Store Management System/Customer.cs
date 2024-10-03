public interface ICustomer
{
    string FirstName {get; }
    string LastName {get; }
    void DisplayCustomerDetails();
}

public class Customer : ICustomer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Customer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void DisplayCustomerDetails()
    {
        Console.WriteLine($"Customer: {FirstName} {LastName}");
    }
}
