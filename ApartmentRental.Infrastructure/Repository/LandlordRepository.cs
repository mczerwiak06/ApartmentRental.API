using ApartmentRental.Infrastructure.Entities;

namespace ApartmentRental.Infrastructure.Repository;

public class LandlordRepository : ILandlordRepository
{
    public Task<IEnumerable<Landlord>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Landlord> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Landlord entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Landlord entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}