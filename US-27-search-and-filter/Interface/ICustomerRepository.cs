using US_27_search_and_filter.Models;

namespace US_27_search_and_filter.Interface;

public interface ICustomerRepository
{
    void AddCustomer(Customer customer);
    Customer? GetCustomerById(Guid customerId);
    List<Customer> GetAllCustomers();
    bool ExistByOrganizationNumber(string  organizationNumber);
}
