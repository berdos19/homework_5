namespace Homework_5;

public class CustomerService : ICustomerService
{
    private readonly List<Customer> _customers = new List<Customer>();

    public IEnumerable<Customer> GetAll()
    {
        return _customers;
    }

    public Customer GetById(int id)
    {
        return _customers.FirstOrDefault(c => c.Id == id);
    }

    public void Add(Customer customer)
    {
        _customers.Add(customer);
    }

    public void Update(int id, Customer customer)
    {
        var existingCustomer = GetById(id);
        if (existingCustomer != null)
        {
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.Number = customer.Number;
        }
    }

    public void Delete(int id)
    {
        var customer = GetById(id);
        if (customer != null)
        {
            _customers.Remove(customer);
        }
    }
}
