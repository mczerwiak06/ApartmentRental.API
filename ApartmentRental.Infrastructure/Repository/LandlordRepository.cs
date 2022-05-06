using ApartmentRental.Infrastructure.Entities;

namespace ApartmentRental.Infrastructure.Repository;

public class LandlordRepository : ILandlordRepository
{
    public Task<IEnumerable<Landlord>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Landlord> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Landlord entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Landlord entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
