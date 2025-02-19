using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CustomersController : Controller
{
    private readonly ICustomerRepository _repository;

    public CustomersController(ICustomerRepository repository)
    {
        _repository = repository;
    }

/// <summary>
/// Gets all customers.
/// </summary>
[HttpGet]
public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
{
    return Ok(await _repository.GetAllAsync());
}

/// <summary>
/// Gets a customer by ID.
/// </summary>
[HttpGet("{id}")]
public async Task<ActionResult<Customer>> GetCustomer(int id)
{
    var customer = await _repository.GetByIdAsync(id);
    if (customer == null)
    {
        return NotFound();
    }
    return Ok(customer);
}

/// <summary>
/// Creates a new customer.
/// </summary>
[HttpPost]
public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
{
    await _repository.AddAsync(customer);
    return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
}

/// <summary>
/// Updates a customer.
/// </summary>
[HttpPut("{id}")]
public async Task<ActionResult> UpdateCustomer(int id, Customer customer)
{
    if (id != customer.Id)
    {
        return BadRequest();
    }
    await _repository.UpdateAsync(customer);
    return NoContent();
}

/// <summary>
/// Deletes a customer.
/// </summary>
[HttpDelete("{id}")]
public async Task<ActionResult> DeleteCustomer(int id)
{
    await _repository.DeleteAsync(id);
    return NoContent();
}
}
