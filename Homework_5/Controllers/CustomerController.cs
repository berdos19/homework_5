using Microsoft.AspNetCore.Mvc;

namespace Homework_5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var customers = _customerService.GetAll();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var customer = _customerService.GetById(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Customer customer)
    {
        if (customer == null || string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.LastName) ||
            string.IsNullOrEmpty(customer.Email) || string.IsNullOrEmpty(customer.Number))
        {
            return BadRequest("Invalid customer data.");
        }

        _customerService.Add(customer);
        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Customer customer)
    {
        if (customer == null || string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.LastName) ||
            string.IsNullOrEmpty(customer.Email) || string.IsNullOrEmpty(customer.Number))
        {
            return BadRequest("Invalid customer data.");
        }

        var existingCustomer = _customerService.GetById(id);
        if (existingCustomer == null)
        {
            return NotFound();
        }

        _customerService.Update(id, customer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingCustomer = _customerService.GetById(id);
        if (existingCustomer == null)
        {
            return NotFound();
        }

        _customerService.Delete(id);
        return NoContent();
    }
}