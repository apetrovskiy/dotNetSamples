using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{
    private readonly MyDbContext _context;

    public CustomerRepository(MyDbContext context)
    {
        _context = context;
    }

public async Task<IEnumerable<Customer>> GetAllAsync()
{
    return await _context.Customers.Include(c => c.CustomerPreferences).ThenInclude(cp => cp.Preference).ToListAsync();
}

public async Task<Customer> GetByIdAsync(int id)
{
    return await _context.Customers.Include(c => c.CustomerPreferences).ThenInclude(cp => cp.Preference).FirstOrDefaultAsync(c => c.Id == id);
}

public async Task AddAsync(Customer customer)
{
    await _context.Customers.AddAsync(customer);
    await _context.SaveChangesAsync();
}

public async Task UpdateAsync(Customer customer)
{
    _context.Customers.Update(customer);
    await _context.SaveChangesAsync();
}

public async Task DeleteAsync(int id)
{
    var customer = await _context.Customers.FindAsync(id);
    if (customer != null)
    {
        // Delete associated PromoCode
        if (customer.PromoCode != null)
        {
            _context.PromoCodes.Remove(customer.PromoCode);
        }
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}
}
