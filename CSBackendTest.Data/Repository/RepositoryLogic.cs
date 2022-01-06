using CSBackendTest.Data.Context;
using CSBackendTest.Data.Models;

namespace CSBackendTest.Data.Repository;

public class RepositoryLogic : IRepository
{
    private readonly BackendTestContext _context;

    public RepositoryLogic(BackendTestContext context)
    {
        _context = context;
    }
    
    IEnumerable<Customer> IRepository.GetAll() => _context.Customers.ToList();

    public void Add(Customer entity)
    {
        if (entity is null) throw new ArgumentException($"{nameof(entity)} is null");
        _context.Customers.Add(entity);
        _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is default");
        Customer customer = await _context.Customers.FindAsync(id) ??
                            throw new ArgumentException($"{nameof(customer)} is null");
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Customer entity)
    {
        if (entity is null) 
            throw new ArgumentException($"{nameof(entity)} is null");
        var customer = await _context.Customers.FindAsync(entity.Id);
        if (customer is null)
            throw new ArgumentException($"{nameof(customer)} is null");
        customer.Name = entity.Name;
        customer.Surname = entity.Surname;
        await _context.SaveChangesAsync();
    }

    public async Task<Customer> FindById(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is default");
        Customer customer = await _context.Customers.FindAsync(id) ??
                            throw new ArgumentException($"{nameof(customer)} is null");
        return customer;
    }
}