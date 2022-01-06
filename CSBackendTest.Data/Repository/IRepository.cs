using CSBackendTest.Data.Models;

namespace CSBackendTest.Data.Repository;

public interface IRepository
{
    IEnumerable<Customer> GetAll();

    void Add(Customer entity);

    Task Delete(Guid id);

    Task Update(Customer entity);

    Task<Customer> FindById(Guid id);
}