namespace Aferback.Model.Contracts
{
    public interface ICustomer
    {
        int CustomerID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
    }
}
