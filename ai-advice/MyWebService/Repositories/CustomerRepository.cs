namespace MyWebService.Repositories;

using MyWebService.Controllers;

using MyWebService.Models;
using MyWebService.Data;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;

public class CustomerRepository<Customer> : IRepository<Customer>
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return Task.FromResult(_context.Customers.Include(c => c.CustomerPreferences).ThenInclude(cp => cp.Preference).AsEnumerable());
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
