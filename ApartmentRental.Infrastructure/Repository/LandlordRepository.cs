using ApartmentRental.Infrastructure.Context;
using ApartmentRental.Infrastructure.Entities;
using ApartmentRental.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ApartmentRental.Infrastructure.Repository;

public class LandlordRepository : ILandlordRepository
{
    private readonly MainContext _mainContext;

    public LandlordRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    public async Task<IEnumerable<Landlord>> GetAllAsync()
    {
        var landlord = await _mainContext.Landlord.ToListAsync();
        return landlord;
    }

    public async Task<Landlord> GetByIdAsync(int id)
    {
        var landlord = await _mainContext.Landlord.SingleOrDefaultAsync(x => x.Id == id);
        if (landlord == null)
        {
            throw new EntityNotFoundException();
        }

        return landlord;
    }

    public async Task AddAsync(Landlord entity)
    {
        var landlordToAdd = await _mainContext.Landlord.AnyAsync(x => x.Id == entity.Id);
        if (landlordToAdd)
        {
            throw new EntityAlreadyExistsException();
        }
        entity.DateOfCreation = DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Landlord entity)
    {
        var landlordToUpdate = await _mainContext.Landlord.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (landlordToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        landlordToUpdate.Apartments = entity.Apartments;
        landlordToUpdate.AccountId = entity.AccountId;
        landlordToUpdate.Account = entity.Account;
        landlordToUpdate.DateOfUpdate = DateTime.UtcNow;
        await _mainContext.SaveChangesAsync();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
