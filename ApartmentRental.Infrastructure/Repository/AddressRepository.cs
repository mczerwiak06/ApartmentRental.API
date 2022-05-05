using ApartmentRental.Infrastructure.Entities;

namespace ApartmentRental.Infrastructure.Repository;

public class AddressRepository : IAddressRepository
{
    public Task<IEnumerable<Address>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Address> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Address entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Address entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}