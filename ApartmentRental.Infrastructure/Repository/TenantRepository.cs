using ApartmentRental.Infrastructure.Entities;

namespace ApartmentRental.Infrastructure.Repository;

public class TenantRepository : ITenantRepository
{
    public Task<IEnumerable<Tenant>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Tenant> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Tenant entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Tenant entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}