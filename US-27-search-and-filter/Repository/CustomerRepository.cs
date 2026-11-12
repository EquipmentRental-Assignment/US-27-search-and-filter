using US_27_search_and_filter.Models;
using US_27_search_and_filter.Interface;

namespace US_27_search_and_filter.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customerList = [];

    public void AddCustomer(Customer customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer), "You cannot add an empty customer!");

        _customerList.Add(customer);
    }

    public Customer? GetCustomerById(Guid customerId)
    {
        return _customerList.FirstOrDefault(c => c.CustomerId == customerId);
    }

    public List<Customer> GetAllCustomers()
    {
        return _customerList.ToList();
    }

    public bool ExistByOrganizationNumber(string organizationNumber)
    {
        if (string.IsNullOrWhiteSpace(organizationNumber))
            return false;

        return _customerList.Any(c => c.OrganizationNumber == organizationNumber);
    }
}