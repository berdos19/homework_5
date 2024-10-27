namespace Homework_5;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();
    Customer GetById(int id);
    void Add(Customer customer);
    void Update(int id, Customer customer);
    void Delete(int id);
}
