using ApartmentRental.Infrastructure.Entities;

namespace ApartmentRental.Infrastructure.Repository;

public class TenantRepository : ITenantRepository
{
    public Task<IEnumerable<Tenant>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Tenant> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Tenant entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Tenant entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}